namespace HouseRentingSystem.Infrastructure.SeedDb;

using Microsoft.AspNetCore.Identity;
using Models;

public class SeedData
{
    public SeedData()
    {
        SeedUsers();
        SeedAgent();
        SeedCategories();
        SeedHouses();
    }

    public ApplicationUser AgentUser { get; set; } = null!;

    public ApplicationUser GuestUser { get; set; } = null!;

    public ApplicationUser AdminUser { get; set; } = null!;

    public Agent Agent { get; set; } = null!;

    public Agent AdminAgent { get; set; } = null!;

    public Category CottageCategory { get; set; } = null!;

    public Category SingleCategory { get; set; } = null!;

    public Category DuplexCategory { get; set; } = null!;

    public House FirstHouse { get; set; } = null!;

    public House SecondHouse { get; set; } = null!;

    public House ThirdHouse { get; set; } = null!;

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        AgentUser = new ApplicationUser
        {
            Id = "dea12856-c198-4129-b3f3-b893d8395082",
            UserName = "agent@mail.com",
            NormalizedUserName = "agent@mail.com",
            Email = "agent@mail.com",
            NormalizedEmail = "agent@mail.com",
            FirstName = "Linda",
            LastName = "Michaels"
        };

        AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent123");

        GuestUser = new ApplicationUser
        {
            Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
            UserName = "guest@mail.com",
            NormalizedUserName = "guest@mail.com",
            Email = "guest@mail.com",
            NormalizedEmail = "guest@mail.com",
            FirstName = "Teodor",
            LastName = "Lesly"
        };

        GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "guest123");

        AdminUser = new ApplicationUser
        {
            Id = "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
            Email = "admin@mail.com",
            NormalizedEmail = "admin@mail.com",
            UserName = "admin@mail.com",
            NormalizedUserName = "admin@mail.com",
            FirstName = "Great",
            LastName = "Admin"
        };

        AdminUser.PasswordHash = hasher.HashPassword(AgentUser, "admin123");
    }

    private void SeedAgent()
    {
        Agent = new Agent
        {
            Id = 1,
            PhoneNumber = "+359888888888",
            UserId = AgentUser.Id
        };

        AdminAgent = new Agent
        {
            Id = 5,
            PhoneNumber = "+359123456789",
            UserId = AdminUser.Id
        };
    }

    private void SeedCategories()
    {
        CottageCategory = new Category
        {
            Id = 1,
            Name = "Cottage"
        };

        SingleCategory = new Category
        {
            Id = 2,
            Name = "Single-Family"
        };

        DuplexCategory = new Category
        {
            Id = 3,
            Name = "Duplex"
        };
    }

    private void SeedHouses()
    {
        FirstHouse = new House
        {
            Id = 1,
            Title = "Big House Marina",
            Address = "North London, UK (near the border)",
            Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
            ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
            PricePerMonth = 2100.00M,
            CategoryId = DuplexCategory.Id,
            AgentId = Agent.Id,
            RenterId = GuestUser.Id
        };

        SecondHouse = new House
        {
            Id = 2,
            Title = "Family House Comfort",
            Address = "Near the Sea Garden in Burgas, Bulgaria",
            Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
            PricePerMonth = 1200.00M,
            CategoryId = SingleCategory.Id,
            AgentId = Agent.Id
        };

        ThirdHouse = new House
        {
            Id = 3,
            Title = "Grand House",
            Address = "Boyana Neighbourhood, Sofia, Bulgaria",
            Description = "This luxurious house is everything you will need. It is just excellent.",
            ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
            PricePerMonth = 2000.00M,
            CategoryId = SingleCategory.Id,
            AgentId = Agent.Id
        };
    }
}