namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserClaimConfiguration : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        var data = new SeedData();
        builder.HasData(data.AgentUserClaim, data.GuestUserClaim, data.AdminUserClaim);
    }
}