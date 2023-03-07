namespace MiniORM
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class ChangeTracker<T> where T : class, new()
    {
        private readonly IList<T> _allEntities;
        private readonly IList<T> _added;
        private readonly IList<T> _removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            _added = new List<T>();
            _removed = new List<T>();
            _allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => (IReadOnlyCollection<T>)_allEntities;
        public IReadOnlyCollection<T> Added => (IReadOnlyCollection<T>)_added;
        public IReadOnlyCollection<T> Removed => (IReadOnlyCollection<T>)_removed;

        public void Add(T entity) => _added.Add(entity);

        public void Remove(T entity) => _removed.Add(entity);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();
            PropertyInfo[] primaryKeys = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (T proxyEntity in AllEntities)
            {
                object?[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                T entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));

                if (IsModified(proxyEntity, entity))
                    modifiedEntities.Add(entity);
            }

            return modifiedEntities;
        }

        private static IList<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();
            var propertiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (T entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in propertiesToClone)
                {
                    property.SetValue(clonedEntity, property.GetValue(entity));
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }

        private static IEnumerable<object?> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
            => primaryKeys.Select(pk => pk.GetValue(entity));

        private static bool IsModified(T proxyEntity, T entity)
        {
            IEnumerable<PropertyInfo> monitoredProperties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            return monitoredProperties.Any(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)));
        }
    }
}