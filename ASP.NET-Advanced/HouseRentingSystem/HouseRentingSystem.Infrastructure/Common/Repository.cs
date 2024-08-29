namespace HouseRentingSystem.Infrastructure.Common;

using Microsoft.EntityFrameworkCore;

public class Repository : IRepository
{
    private readonly DbContext context;

    public Repository(HouseRentingDbContext context)
    {
        this.context = context;
    }

    public IQueryable<T> All<T>() where T : class => context.Set<T>();

    public async Task AddAsync<T>(T entity) where T : class => await context.Set<T>().AddAsync(entity);

    public void Delete<T>(T entity) where T : class => context.Set<T>().Remove(entity);

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

    public async Task<T?> FindAsync<T>(params object?[]? keyValues) where T : class 
        => await context.Set<T>().FindAsync(keyValues);
}