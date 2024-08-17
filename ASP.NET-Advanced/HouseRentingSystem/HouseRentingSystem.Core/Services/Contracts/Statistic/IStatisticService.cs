namespace HouseRentingSystem.Core.Services.Contracts.Statistic;

using Models.Statistic;

public interface IStatisticService
{
    Task<StatisticServiceModel> TotalAsync();
}