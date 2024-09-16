namespace HouseRentingSystem.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Areas.Admin;
using Attributes;
using static Common.MessageConstants;
using Core.Models.House;
using Core.Services.Contracts.Agent;
using Core.Services.Contracts.House;

public class HouseController(IHouseService houseService, IAgentService agentService, IMemoryCache cache) : BaseController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel model)
    {
        await houseService.GetAllAsync(model);
        model.Categories = await houseService.GetAllCategoriesNamesAsync();

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        if (User.IsAdmin())
        {
            return RedirectToAction(nameof(Areas.Admin.Controllers.HouseController.Mine), "House",
                new { area = AdminConstants.AreaName });
        }

        string userId = User.Id()!;
        int? agentId = await agentService.GetAgentIdAsync(userId);

        var houses = agentId.HasValue 
            ? await houseService.GetAllHousesByAgentIdAsync(agentId.Value)
            : await houseService.GetAllHousesByUserIdAsync(userId);

        return View(houses);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, string information)
    {
        HouseDetailsServiceModel? house = await houseService.GetDetailsByIdAsync(id);

        if (house is null || information != house.GetInformation())
        {
            return BadRequest();
        }

        return View(house);
    }

    [HttpGet]
    [IsAgent]
    public async Task<IActionResult> Add()
    {
        var model = new HouseFormModel
        {
            Categories = await houseService.GetAllCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    [IsAgent]
    public async Task<IActionResult> Add(HouseFormModel model)
    {
        if (!await houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await houseService.GetAllCategoriesAsync();
            return View(model);
        }

        int agentId = (await agentService.GetAgentIdAsync(User.Id()!))!.Value;
        int newHouseId = await houseService.CreateAsync(model, agentId);

        if (User.IsAdmin())
        {
            await houseService.ApproveAsync(newHouseId);
            TempData[SuccessMessage] = "You have successfully added a house!";

            return RedirectToAction(nameof(Details), new { id = newHouseId, information = model.GetInformation() });
        }

        TempData[SuccessMessage] = "You have successfully sent a new house for approval!";
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        HouseFormModel? house = await houseService.GetFormModelByIdAsync(id);

        if (house is null)
        {
            return BadRequest();
        }

        if (!User.IsAdmin() && !await houseService.HouseHasAgentWithUserId(id, User.Id()!))
        {
            return Unauthorized();
        }

        return View(house);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, HouseFormModel house)
    {
        if (!await houseService.ExistsByIdAsync(id))
        {
            return BadRequest();
        }

        if (!User.IsAdmin() && !await houseService.HouseHasAgentWithUserId(id, User.Id()!))
        {
            return Unauthorized();
        }

        if (!await houseService.CategoryExistsAsync(house.CategoryId))
        {
            ModelState.AddModelError(nameof(house.CategoryId), "Category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            house.Categories = await houseService.GetAllCategoriesAsync();
            return View(house);
        }

        await houseService.EditAsync(id, house);
        TempData[SuccessMessage] = "You have successfully edited a house!";

        return RedirectToAction(nameof(Details), new { id, information = house.GetInformation() });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var house = await houseService.GetDetailsByIdAsync(id);

        if (house is null)
        {
            return BadRequest();
        }

        if (!User.IsAdmin() && !await houseService.HouseHasAgentWithUserId(id, User.Id()!))
        {
            return Unauthorized();
        }

        return View(house);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseIndexServiceModel house)
    {
        if (!await houseService.ExistsByIdAsync(house.Id))
        {
            return BadRequest();
        }

        if (!User.IsAdmin() && !await houseService.HouseHasAgentWithUserId(house.Id, User.Id()!))
        {
            return Unauthorized();
        }

        await houseService.DeleteAsync(house.Id);
        TempData[SuccessMessage] = "You have successfully deleted a house!";

        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Rent(int id)
    {
        var house = await houseService.GetDetailsByIdAsync(id);

        if (house is null || house.IsRented)
        {
            return BadRequest();
        }

        if (!User.IsAdmin() && await agentService.ExistsByIdAsync(User.Id()!))
        {
            return Unauthorized();
        }

        await houseService.RentAsync(id, User.Id()!);
        cache.Remove(AdminConstants.RentsCacheKey);
        TempData[SuccessMessage] = "You have successfully rented a house!";

        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var house = await houseService.GetDetailsByIdAsync(id);

        if (house is null || !house.IsRented)
        {
            return BadRequest();
        }

        if (!await houseService.IsRentedByUserWithIdAsync(id, User.Id()!))
        {
            return Unauthorized();
        }

        await houseService.LeaveAsync(id);
        cache.Remove(AdminConstants.RentsCacheKey);
        TempData[SuccessMessage] = "You have successfully left a house!";

        return RedirectToAction(nameof(Mine));
    }
}