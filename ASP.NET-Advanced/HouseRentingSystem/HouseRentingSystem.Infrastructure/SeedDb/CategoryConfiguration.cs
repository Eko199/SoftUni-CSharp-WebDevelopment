namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var data = new SeedData();
        builder.HasData(data.CottageCategory, data.SingleCategory, data.DuplexCategory);
    }
}