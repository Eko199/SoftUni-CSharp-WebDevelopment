namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class AgentConfiguration : IEntityTypeConfiguration<Agent>
{
    public void Configure(EntityTypeBuilder<Agent> builder)
    {
        var data = new SeedData();
        builder.HasData(data.Agent, data.AdminAgent);
    }
}