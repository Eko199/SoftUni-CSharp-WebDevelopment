namespace HouseRentingSystem.Tests.Mocks;

using Core.Models.Statistic;
using Core.Services.Contracts.Statistic;
using Moq;

public static class StatisticServiceMock
{
    public static StatisticServiceModel StatisticModel { get; } = new()
    {
        TotalHouses = 10,
        TotalRents = 6
    };

    public static IStatisticService Instance
    {
        get
        {
            var mock = new Mock<IStatisticService>();

            mock.Setup(s => s.TotalAsync())
                .ReturnsAsync(StatisticModel);

            return mock.Object;
        }
    }
}