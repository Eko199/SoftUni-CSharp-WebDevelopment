namespace ProductsApi.Data;

using Microsoft.EntityFrameworkCore;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
    { }

    public DbSet<Product> Products { get; init; } = null!;
}