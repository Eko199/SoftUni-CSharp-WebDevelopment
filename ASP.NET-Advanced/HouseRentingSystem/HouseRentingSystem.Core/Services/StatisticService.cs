namespace HouseRentingSystem.Core.Services;

using Contracts.Statistic;
using Infrastructure.Common;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Models.Statistic;

public class StatisticService(IRepository data) : IStatisticService
{
    public async Task<StatisticServiceModel> TotalAsync()
        => new()
        {
            TotalHouses = await data.All<House>().CountAsync(),
            TotalRents = await data.All<House>().CountAsync(h => h.RenterId != null)
        };
}