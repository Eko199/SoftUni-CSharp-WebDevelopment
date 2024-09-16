namespace HouseRentingSystem.Infrastructure;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using SeedDb;

public class HouseRentingDbContext(DbContextOptions<HouseRentingDbContext> options, bool seed)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<House> Houses { get; set; } = null!;

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<Agent> Agents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        if (seed)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserClaimConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new HouseConfiguration());
        }
        else
        {
            builder.Entity<House>().HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<House>().HasOne(h => h.Agent)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

        base.OnModelCreating(builder);
    }
}