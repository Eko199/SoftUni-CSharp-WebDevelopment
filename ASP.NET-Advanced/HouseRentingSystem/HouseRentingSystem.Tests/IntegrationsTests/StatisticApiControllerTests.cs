namespace HouseRentingSystem.Tests.IntegrationsTests;

using Controllers.Api;
using Mocks;

public class StatisticApiControllerTests
{
    private StatisticApiController statisticController;

    [OneTimeSetUp]
    public void SetUp() => statisticController = new StatisticApiController(StatisticServiceMock.Instance);

    [Test]
    public async Task GetStatistic_ShouldReturnCorrectCounts()
    {
        var result = await statisticController.GetStatistic();

        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.TotalHouses, Is.EqualTo(StatisticServiceMock.StatisticModel.TotalHouses));
        Assert.That(result.Value.TotalRents, Is.EqualTo(StatisticServiceMock.StatisticModel.TotalRents));
    }
}