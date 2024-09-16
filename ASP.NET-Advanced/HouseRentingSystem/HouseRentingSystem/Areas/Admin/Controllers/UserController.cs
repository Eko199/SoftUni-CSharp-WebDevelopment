namespace HouseRentingSystem.Areas.Admin.Controllers;

using Core.Models.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Contracts.ApplicationUser;
using Microsoft.Extensions.Caching.Memory;

public class UserController(IApplicationUserService userService, IMemoryCache cache) : AdminBaseController
{
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var users = cache.Get<IEnumerable<UserServiceModel>>(AdminConstants.UsersCacheKey);

        if (users is null || !users.Any())
        {
            users = await userService.GetAllAsync();

            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            cache.Set(AdminConstants.UsersCacheKey, users, cacheOptions);
        }

        return View(users);
    }
}