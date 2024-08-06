namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class HouseConfiguration : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.HasOne(h => h.Category)
            .WithMany(c => c.Houses)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(h => h.Agent)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        var data = new SeedData();
        builder.HasData(data.FirstHouse, data.SecondHouse, data.ThirdHouse);
    }
}