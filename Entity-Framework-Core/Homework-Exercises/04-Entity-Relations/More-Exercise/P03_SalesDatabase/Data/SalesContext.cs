namespace P03_SalesDatabase.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class SalesContext : DbContext
{
    public SalesContext() { }

    public SalesContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB; Database=Sales; Integrated Security=True;");
        }

        base.OnConfiguring(optionsBuilder);
    }
}