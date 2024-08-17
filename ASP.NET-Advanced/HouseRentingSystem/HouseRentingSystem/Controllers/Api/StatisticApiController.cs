namespace HouseRentingSystem.Controllers.Api;

using Core.Models.Statistic;
using Core.Services.Contracts.Statistic;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/statistic")]
public class StatisticApiController(IStatisticService statistics) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<StatisticServiceModel>> GetStatistic() => await statistics.TotalAsync();
}