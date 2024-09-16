namespace HouseRentingSystem.Tests.UnitTests;

using Core.Models.House;
using Core.Services;
using Core.Services.Contracts.ApplicationUser;
using Core.Services.Contracts.House;
using Infrastructure.Models;

public class HouseServiceTests : UnitTestsBase
{
    private IApplicationUserService userService;
    private IHouseService houseService;

    [OneTimeSetUp]
    public void SetUp()
    {
        userService = new ApplicationUserService(repo);
        houseService = new HouseService(repo, userService, mapper);
    }

    [Test]
    public async Task GetAllCategoryNames_ShouldReturnCorrectResult()
    {
        var categoryNames = (await houseService.GetAllCategoriesNamesAsync()).ToList();
        var dbCategoryNames = repo.All<Category>().Select(c => c.Name);

        Assert.That(categoryNames, Has.Count.EqualTo(dbCategoryNames.Count()));
        Assert.That(dbCategoryNames.Contains(categoryNames.First()));
    }

    [Test]
    public async Task GetAllHousesByAgentId_ShouldReturnCorrectHouses()
    {
        var houses = (await houseService.GetAllHousesByAgentIdAsync(Agent.Id)).ToList();
        int dbHousesCount = repo.All<House>().Count(h => h.AgentId == Agent.Id && h.IsApproved);

        Assert.That(houses, Has.Count.EqualTo(dbHousesCount));
    }

    [Test]
    public async Task GetAllHousesByUserId_ShouldReturnCorrectHouses()
    {
        var houses = (await houseService.GetAllHousesByUserIdAsync(Renter.Id)).ToList();
        int dbHousesCount = repo.All<House>().Count(h => h.RenterId == Renter.Id && h.IsApproved);

        Assert.That(houses, Has.Count.EqualTo(dbHousesCount));
    }

    [Test]
    public async Task ExistsById_ShouldReturnCorrectTrueWithValidId()
    {
        Assert.That(await houseService.ExistsByIdAsync(RentedHouse.Id));
    }

    [Test]
    public async Task GetDetailsById_ShouldReturnCorrectHouseData()
    {
        HouseDetailsServiceModel? houseDetails = await houseService.GetDetailsByIdAsync(RentedHouse.Id);
        House dbHouse = (await repo.FindAsync<House>(RentedHouse.Id))!;

        Assert.That(houseDetails, Is.Not.Null);
        Assert.That(houseDetails.Id, Is.EqualTo(dbHouse.Id));
        Assert.That(houseDetails.Title, Is.EqualTo(dbHouse.Title));
    }

    [Test]
    public async Task GetAllCategories_ShouldReturnCorrectCategories()
    {
        var categories = (await houseService.GetAllCategoriesAsync()).ToList();
        var dbCategoryNames = repo.All<Category>().Select(c => c.Name);

        Assert.That(categories, Has.Count.EqualTo(dbCategoryNames.Count()));
        Assert.That(dbCategoryNames.Contains(categories.First().Name));
    }

    [Test]
    public async Task Create_ShouldCreateHouse()
    {
        int countBefore = repo.All<House>().Count();

        var newHouse = new HouseFormModel
        {
            Title = "New House",
            Address = "In a Galaxy far far away...",
            Description = "On a very hot sandy planet, in the outskirts of the capital city",
            ImageUrl = "https://www.pexels.com/house-lights-turned-on-106399/",
            PricePerMonth = 2200,
            CategoryId = 1
        };

        int newHouseId = await houseService.CreateAsync(newHouse, Agent.Id);
        House dbNewHouse = (await repo.FindAsync<House>(newHouseId))!;

        Assert.That(repo.All<House>().ToList(), Has.Count.EqualTo(countBefore + 1));
        Assert.That(dbNewHouse.Title, Is.EqualTo(newHouse.Title));
    }

    [Test]
    public async Task HouseHasAgentWithId_ShouldReturnTrueWithValidId()
    {
        Assert.That(await houseService.HouseHasAgentWithUserId(RentedHouse.Id, RentedHouse.Agent.User.Id));
    }

    [Test]
    public async Task Edit_ShouldEditHouseCorrectly()
    {
        var house = new House
        {
            Title = "New House for Edit",
            Address = "Sofia",
            Description = "This house is a test house that must be edit",
            ImageUrl = "https://www.pexels.com/photo/house-lights-turne"
        };

        await repo.AddAsync(house);
        await repo.SaveChangesAsync();

        var formModel = new HouseFormModel
        {
            Title = house.Title,
            Address = "Sofia, Bulgaria",
            Description = house.Description,
            ImageUrl = house.ImageUrl,
            PricePerMonth = house.PricePerMonth,
            CategoryId = house.CategoryId
        };

        await houseService.EditAsync(house.Id, formModel);

        House? editedHouse = await repo.FindAsync<House>(house.Id);

        Assert.That(editedHouse, Is.Not.Null);
        Assert.That(editedHouse.Title, Is.EqualTo(house.Title));
        Assert.That(editedHouse.Address, Is.EqualTo(formModel.Address));
    }

    [Test]
    public async Task Delete_ShouldDeleteHouseSuccessfully()
    {
        var house = new House
        {
            Title = "New House for delete",
            Address = "Sofia",
            Description = "This house is a test house that must be delete",
            ImageUrl = "https://www.pexels.com/photo/house-lights-turned-"
        };

        await repo.AddAsync(house);
        await repo.SaveChangesAsync();

        int housesCountBefore = repo.All<House>().Count();
        await houseService.DeleteAsync(house.Id);
        House? deletedHouse = await repo.FindAsync<House>(house.Id);

        Assert.That(repo.All<House>().ToList(), Has.Count.EqualTo(housesCountBefore - 1));
        Assert.That(deletedHouse, Is.Null);
    }

    [Test]
    public async Task IsRentedByUserWithId_ShouldReturnCorrectTrueWithValidIds()
    {
        Assert.That(await houseService.IsRentedByUserWithIdAsync(RentedHouse.Id, RentedHouse.RenterId!));
    }

    [Test]
    public async Task Rent_ShouldRentHouseSuccessfully()
    {
        var house = new House
        {
            Title = "New House for rent",
            Address = "A little to the left from the middle of nowhere",
            Description = "This house is a test house that must be rented",
            ImageUrl = "https://www.pexels.com/photo/house-lights-turned-on-106399/"
        };

        await repo.AddAsync(house);
        await repo.SaveChangesAsync();

        await houseService.RentAsync(house.Id, Renter.Id);
        House? rentedHouse = await repo.FindAsync<House>(house.Id);

        Assert.That(rentedHouse, Is.Not.Null);
        Assert.That(Renter.Id, Is.EqualTo(rentedHouse.RenterId));
    }

    [Test]
    public async Task Leave_ShouldLeaveHouseSuccessfully()
    {
        var house = new House
        {
            Title = "New House for leave",
            Address = "Somewhere in the middle of nowhere",
            Description = "This house is a test house that must be left",
            ImageUrl = "https://www.pexels.com/photo/house-lights-turned-on-106399/",
            RenterId = "TestRenterId"
        };

        await repo.AddAsync(house);
        await repo.SaveChangesAsync();

        await houseService.LeaveAsync(house.Id);
        House? leftHouse = await repo.FindAsync<House>(house.Id);

        Assert.That(house.RenterId, Is.Null);
        Assert.That(leftHouse, Is.Not.Null);
        Assert.That(leftHouse.RenterId, Is.Null);
    }

    [Test]
    public async Task GetLastThreeHouses_ShouldReturnCorrectHouses()
    {
        var houses = (await houseService.GetLastThreeHousesAsync()).ToList();

        var dbHouses = repo.All<House>()
            .Where(h => h.IsApproved)
            .OrderByDescending(h => h.Id)
            .Take(3)
            .ToList();

        var firstHouse = houses.First();
        var dbFirstHouse = dbHouses.First();

        Assert.That(houses, Has.Count.EqualTo(dbHouses.Count()));
        Assert.That(firstHouse.Id, Is.EqualTo(dbFirstHouse.Id));
        Assert.That(firstHouse.Title, Is.EqualTo(dbFirstHouse.Title));
    }
}