namespace HouseRentingSystem.Infrastructure.Common;

public interface IRepository
{
    IQueryable<T> All<T>() where T : class;

    Task AddAsync<T>(T entity) where T : class;

    void Delete<T>(T entity) where T : class;

    Task<int> SaveChangesAsync();

    Task<T?> FindAsync<T>(params object?[]? keyValues) where T : class;
}