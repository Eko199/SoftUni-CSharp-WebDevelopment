namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var data = new SeedData();
        builder.HasData(data.AgentUser, data.GuestUser, data.AdminUser);
    }
}