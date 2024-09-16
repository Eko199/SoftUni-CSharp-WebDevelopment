namespace HouseRentingSystem.Tests.UnitTests;

using Core.Models.Rent;
using Core.Services;
using Core.Services.Contracts.Rent;
using Infrastructure.Models;

[TestFixture]
public class RentServiceTests : UnitTestsBase
{
    private IRentService rentService;

    [OneTimeSetUp]
    public void SetUp() => rentService = new RentService(repo);

    [Test]
    public async Task All_ShouldReturnCorrectData()
    {
        List<RentServiceModel> rents = (await rentService.GetAllAsync()).ToList();

        int rentsCount = repo.All<House>().Count(h => h.RenterId != null);
        RentServiceModel? resultHouseRent = rents.Find(h => h.HouseTitle == RentedHouse.Title);

        Assert.That(rents, Has.Count.EqualTo(rentsCount));
        Assert.That(resultHouseRent, Is.Not.Null);
        Assert.That(Renter.Email, Is.EqualTo(resultHouseRent.RenterEmail));
        Assert.That($"{Renter.FirstName} {Renter.LastName}", Is.EqualTo(resultHouseRent.RenterFullName));
        Assert.That(Agent.User.Email, Is.EqualTo(resultHouseRent.AgentEmail));
        Assert.That($"{Agent.User.FirstName} {Agent.User.LastName}", Is.EqualTo(resultHouseRent.AgentFullName));
    }
}