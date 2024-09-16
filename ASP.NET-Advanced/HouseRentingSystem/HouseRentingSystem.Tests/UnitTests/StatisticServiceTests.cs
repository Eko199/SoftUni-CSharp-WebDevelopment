namespace HouseRentingSystem.Tests.UnitTests;

using Core.Models.Statistic;
using Core.Services;
using Core.Services.Contracts.Statistic;
using Infrastructure.Models;

[TestFixture]
public class StatisticServiceTests : UnitTestsBase
{
    private IStatisticService statisticService;

    [OneTimeSetUp]
    public void SetUp() => statisticService = new StatisticService(repo);

    [Test]
    public async Task Total_ShouldReturnCorrectCounts()
    {
        StatisticServiceModel result = await statisticService.TotalAsync();

        int housesCount = repo.All<House>().Count();
        int rentsCount = repo.All<House>().Count(h => h.RenterId != null);

        Assert.That(result.TotalHouses, Is.EqualTo(housesCount));
        Assert.That(result.TotalRents, Is.EqualTo(rentsCount));
    }
}