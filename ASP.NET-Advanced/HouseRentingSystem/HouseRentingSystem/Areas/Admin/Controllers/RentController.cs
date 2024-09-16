namespace HouseRentingSystem.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Core.Models.Rent;
using Core.Services.Contracts.Rent;

public class RentController(IRentService rentService, IMemoryCache cache) : AdminBaseController
{
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var rents = cache.Get<IEnumerable<RentServiceModel>>(AdminConstants.RentsCacheKey);

        if (rents is null || !rents.Any())
        {
            rents = await rentService.GetAllAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
            cache.Set(AdminConstants.RentsCacheKey, rents, cacheOptions);
        }

        return View(rents);
    }
}