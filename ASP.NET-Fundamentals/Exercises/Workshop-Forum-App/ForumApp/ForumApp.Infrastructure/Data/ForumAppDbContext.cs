namespace ForumApp.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Configuration;
using Models;

public class ForumAppDbContext : DbContext
{
    public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}