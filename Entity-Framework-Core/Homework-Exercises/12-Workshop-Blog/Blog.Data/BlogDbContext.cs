namespace Blog.Data;

using Microsoft.EntityFrameworkCore;

using Models;

public class BlogDbContext : DbContext
{
    protected BlogDbContext() { }

    public BlogDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Article> Articles { get; set; } = null!;

    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
}