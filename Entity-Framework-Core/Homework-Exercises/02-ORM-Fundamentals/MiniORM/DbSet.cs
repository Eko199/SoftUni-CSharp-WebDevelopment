namespace MiniORM;

using System.Collections;

public class DbSet<TEntity> : ICollection<TEntity>
    where TEntity : class, new()
{
    internal DbSet(IEnumerable<TEntity> entities)
    {
        Entities = entities.ToList();
        ChangeTracker = new ChangeTracker<TEntity>(entities);
    }

    public int Count => Entities.Count;
    public bool IsReadOnly => Entities.IsReadOnly;

    internal ChangeTracker<TEntity> ChangeTracker { get; set; }
    internal IList<TEntity> Entities { get; set; }

    public void Add(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        Entities.Add(entity);
        ChangeTracker.Add(entity);
    }

    public bool Remove(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        bool removedSuccessfully = Entities.Remove(entity);

        if (removedSuccessfully)
            ChangeTracker.Remove(entity);

        return removedSuccessfully;
    }

    public bool Contains(TEntity entity) => Entities.Contains(entity);

    public void Clear()
    {
        while (Entities.Any())
            Remove(Entities.First());
    }

    public void CopyTo(TEntity[] array, int arrayIndex) => Entities.CopyTo(array, arrayIndex);

    public void RemoveRange(IEnumerable<TEntity> entities) => entities.ToList().ForEach(e => Remove(e));

    public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}