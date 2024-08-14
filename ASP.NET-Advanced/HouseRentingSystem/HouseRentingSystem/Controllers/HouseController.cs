namespace HouseRentingSystem.Controllers;

using System.Security.Claims;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Models.House;
using Core.Services.Contracts.Agent;
using Core.Services.Contracts.House;

public class HouseController : BaseController
{
    private readonly IHouseService houseService;
    private readonly IAgentService agentService;

    public HouseController(IHouseService houseService, IAgentService agentService)
    {
        this.houseService = houseService;
        this.agentService = agentService;
    }

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
        string userId = User.Id()!;
        int? agentId = await agentService.GetAgentIdAsync(userId);

        var houses = agentId.HasValue 
            ? await houseService.GetAllHousesByAgentIdAsync(agentId.Value)
            : await houseService.GetAllHousesByUserIdAsync(userId);

        return View(houses);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        HouseDetailsServiceModel? house = await houseService.GetDetailsByIdAsync(id);
        return house is null ? BadRequest() : View(house);
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
        int newHouseId = await houseService.Create(model, agentId);

        return RedirectToAction(nameof(Details), new { id = newHouseId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        HouseFormModel? house = await houseService.GetFormModelByIdAsync(id);

        if (house is null)
        {
            return BadRequest();
        }

        if (!await houseService.HouseHasAgentWithUserId(id, User.Id()!))
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

        if (!await houseService.HouseHasAgentWithUserId(id, User.Id()!))
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
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var house = await houseService.GetDetailsByIdAsync(id);

        if (house is null)
        {
            return BadRequest();
        }

        if (!await houseService.HouseHasAgentWithUserId(id, User.Id()!))
        {
            return Unauthorized();
        }

        return View(house);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(HouseShortInfoViewModel house)
    {
        if (!await houseService.ExistsByIdAsync(house.Id))
        {
            return BadRequest();
        }

        if (!await houseService.HouseHasAgentWithUserId(house.Id, User.Id()!))
        {
            return Unauthorized();
        }

        await houseService.DeleteAsync(house.Id);
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

        if (await agentService.ExistsByIdAsync(User.Id()!))
        {
            return Unauthorized();
        }

        await houseService.RentAsync(id, User.Id()!);
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
        return RedirectToAction(nameof(Mine));
    }
}