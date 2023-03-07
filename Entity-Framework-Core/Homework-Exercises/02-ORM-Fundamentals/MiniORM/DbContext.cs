namespace MiniORM;

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.Data.SqlClient;

public abstract class DbContext
{
    internal static readonly Type[] AllowedSqlTypes =
    {
        typeof(string),
        typeof(int),
        typeof(uint),
        typeof(long),
        typeof(ulong),
        typeof(decimal),
        typeof(bool),
        typeof(DateTime)
    };

    private readonly DatabaseConnection _connection;
    private readonly IDictionary<Type, PropertyInfo> _dbSetProperties;

    protected DbContext(string connectionString)
    {
        _connection = new DatabaseConnection(connectionString);
        _dbSetProperties = DiscoverDbSets();

        using (new ConnectionManager(_connection))
        {
            InitializeDbSets();
        }

        MapAllRelations();
    }

    public void SaveChanges()
    {
        object?[] dbSets = _dbSetProperties.Select(pi => pi.Value.GetValue(this)).ToArray();

        foreach (IEnumerable<object>? dbSet in dbSets)
        {
            object[] invalidEntities = dbSet!.Where(e => !IsObjectValid(e)).ToArray();

            if (invalidEntities.Any())
                throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities Found in {dbSet!.GetType().Name}");
        }

        using (new ConnectionManager(_connection))
        {
            using SqlTransaction transaction = _connection.StartTransaction();

            foreach (IEnumerable<object>? dbSet in dbSets)
            {
                MethodInfo persistMethod = typeof(DbContext)
                    .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .MakeGenericMethod(dbSet!.GetType().GetGenericArguments().First());

                try
                {
                    persistMethod.Invoke(this, new object[] { dbSet });
                }
                catch (TargetInvocationException tie)
                {
                    throw tie.InnerException!;
                }
                catch (InvalidOperationException)
                {
                    transaction.Rollback();
                    throw;
                }
                catch (SqlException)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            transaction.Commit();
        }
    }

    private static bool IsObjectValid(object e)
    {
        var validationContext = new ValidationContext(e);
        var validationErrors = new List<ValidationResult>();

        return Validator.TryValidateObject(e, validationContext, validationErrors, true);
    }

    private IDictionary<Type, PropertyInfo> DiscoverDbSets()
        => GetType()
            .GetProperties()
            .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
            .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

    private void InitializeDbSets()
    {
        foreach ((Type dbSetType, PropertyInfo dbSetProperty) in _dbSetProperties)
        {
            typeof(DbContext)
                .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(dbSetType)
                .Invoke(this, new object[] { dbSetProperty });
        }
    }

    private void PopulateDbSet<TEntity>(PropertyInfo dbSet) where TEntity : class, new() 
        => ReflectionHelper.ReplaceBackingField(this, dbSet.Name, new DbSet<TEntity>(LoadTableEntities<TEntity>()));

    private IEnumerable<TEntity> LoadTableEntities<TEntity>() where TEntity : class
        => _connection.FetchResultSet<TEntity>(GetTableName(typeof(TEntity)), GetEntityColumnNames(typeof(TEntity)));

    private string GetTableName(Type tableType)
        => tableType.GetCustomAttribute<TableAttribute>()?.Name ?? _dbSetProperties[tableType].Name;

    private string[] GetEntityColumnNames(Type table)
    {
        IEnumerable<string> dbColumns = _connection.FetchColumnNames(GetTableName(table));

        return table.GetProperties()
            .Where(pi => dbColumns.Contains(pi.Name) && !pi.HasAttribute<NotMappedAttribute>() && AllowedSqlTypes.Contains(pi.PropertyType))
            .Select(pi => pi.Name)
            .ToArray();
    }

    private void MapAllRelations()
    {
        foreach ((Type dbSetType, PropertyInfo dbSetProperty) in _dbSetProperties)
        {
            typeof(DbContext)
                .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(dbSetType)
                .Invoke(this, new[] { dbSetProperty.GetValue(this) });
        }
    }

    private void MapRelations<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
    {
        MapNavigationProperties(dbSet);

        IEnumerable<PropertyInfo> collections = typeof(TEntity)
            .GetProperties()
            .Where(pi =>
                pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection));

        foreach (PropertyInfo collection in collections)
        {
            typeof(DbContext)
                .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeof(TEntity), collection.PropertyType.GenericTypeArguments.First())
                .Invoke(this, new object[] { dbSet, collection });
        }
    }

    private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
    {
        Type entityType = typeof(TEntity);

        IEnumerable<PropertyInfo> foreignKeys = entityType.GetProperties()
            .Where(pi => pi.HasAttribute<ForeignKeyAttribute>());

        foreach (PropertyInfo foreignKey in foreignKeys)
        {
            PropertyInfo navigationProperty = entityType.GetProperty(foreignKey.GetCustomAttribute<ForeignKeyAttribute>()!.Name)!;
            IEnumerable<object> navigationDbSet = (IEnumerable<object>)_dbSetProperties[navigationProperty.PropertyType].GetValue(this)!;
            PropertyInfo navigationPrimaryKey = navigationProperty.PropertyType.GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            foreach (TEntity entity in dbSet)
            {
                navigationProperty.SetValue(entity, navigationDbSet
                    .First(navigationEntity => navigationPrimaryKey.GetValue(navigationEntity)!
                        .Equals(foreignKey.GetValue(entity))));
            }
        }
    }

    private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo collectionProperty)
        where TDbSet : class, new()
        where TCollection : class, new()
    {
        Type entityType = typeof(TDbSet);
        Type collectionType = typeof(TCollection);

        PropertyInfo[] primaryKeys = collectionType
            .GetProperties()
            .Where(pi => pi.HasAttribute<KeyAttribute>())
            .ToArray();

        PropertyInfo primaryKey = primaryKeys.First();
        PropertyInfo foreignKey = entityType
            .GetProperties()
            .First(pi => pi.HasAttribute<KeyAttribute>());

        if (primaryKeys.Length >= 2)
        {
            primaryKey = collectionType
                .GetProperties()
                .First(pi => collectionType
                    .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>()!.Name)!
                    .PropertyType == entityType);
        }

        var navigationDbSet = (DbSet<TCollection>)_dbSetProperties[collectionType].GetValue(this)!;
        foreach (TDbSet entity in dbSet)
        {
            ReflectionHelper.ReplaceBackingField(entity, collectionProperty.Name, navigationDbSet
                .Where(navigationEntity => primaryKey.GetValue(navigationEntity)!.Equals(foreignKey.GetValue(entity))));
        }
    }

    private void Persist<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
    {
        string tableName = GetTableName(typeof(TEntity));
        string[] columns = _connection.FetchColumnNames(tableName).ToArray();

        if (dbSet.ChangeTracker.Added.Any())
            _connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);

        TEntity[] modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();

        if (modifiedEntities.Any())
            _connection.UpdateEntities(modifiedEntities, tableName, columns);

        if (dbSet.ChangeTracker.Removed.Any())
            _connection.DeleteEntities(dbSet.ChangeTracker.Removed, tableName, columns);
    }
}