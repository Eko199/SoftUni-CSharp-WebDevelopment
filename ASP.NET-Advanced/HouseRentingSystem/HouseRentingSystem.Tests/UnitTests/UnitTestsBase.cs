namespace HouseRentingSystem.Tests.UnitTests;

using AutoMapper;
using Infrastructure;
using Infrastructure.Common;
using Infrastructure.Models;
using Mocks;

public class UnitTestsBase
{
    private HouseRentingDbContext data;
    protected IMapper mapper;
    protected IRepository repo;

    public ApplicationUser Renter { get; private set; } = null!;

    public Agent Agent { get; private set; } = null!;

    public House RentedHouse { get; private set; } = null!;

    [OneTimeSetUp]
    public void SetUpBase()
    {
        data = DatabaseMock.Instance;
        mapper = MapperMock.Instance;
        repo = new Repository(data);
        SeedDatabase();
    }

    [OneTimeTearDown]
    public void TearDownBase() => data.Dispose();

    private void SeedDatabase()
    {
        Renter = new ApplicationUser
        {
            Id = "RenterUserId",
            Email = "rent@er.bg",
            FirstName = "Renter",
            LastName = "User"
        };

        data.Users.Add(Renter);

        Agent = new Agent
        {
            PhoneNumber = "+359111111111",
            User = new ApplicationUser
            {
                Id = "TestUserId",
                Email = "test@test.bg",
                FirstName = "Test",
                LastName = "Tester"
            }
        };

        data.Agents.Add(Agent);

        RentedHouse = new House
        {
            Title = "First Test House",
            Address = "Test, 201 Test",
            Description = "This is a test description. This is a test description. This is a test description.",
            ImageUrl =
                "https://www.bhg.com/thmb/0Fg0imFSA6HVZMS2DFWPvjbYDoQ=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg",
            Renter = Renter,
            Agent = Agent,
            Category = new Category { Name = "Cottage" },
            IsApproved = true
        };

        data.Houses.Add(RentedHouse);

        var nonRentedHouse = new House
        {
            Title = "Second Test House",
            Address = "Test, 204 Test",
            Description = "This is another test description. This is another test description.",
            ImageUrl = "https://images.adsttc.com/media/images/629f/3517/c372/5201/650f/1c7f/large_jpg/hyde-park-house-robeson-architects_1.jpg?1654601149",
            Renter = Renter,
            Agent = Agent,
            Category = new Category { Name = "Single-Family" },
            IsApproved = true
        };

        data.Houses.Add(nonRentedHouse);
        data.SaveChanges();
    }
}