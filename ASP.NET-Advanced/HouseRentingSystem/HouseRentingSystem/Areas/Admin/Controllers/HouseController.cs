namespace HouseRentingSystem.Areas.Admin.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Contracts.Agent;
using Core.Services.Contracts.House;
using Models;

public class HouseController(IHouseService houseService, IAgentService agentService) : AdminBaseController
{
    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        string userId = User.Id()!;
        int? agentId = await agentService.GetAgentIdAsync(userId);

        var model = new MyHousesViewModel
        {
            AddedHouses = agentId.HasValue
                ? await houseService.GetAllHousesByAgentIdAsync(agentId.Value)
                : [],
            RentedHouses = await houseService.GetAllHousesByUserIdAsync(userId)
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Approve() => View(await houseService.GetAllForApprovalAsync());

    [HttpPost]
    public async Task<IActionResult> Approve(int id)
    {
        await houseService.ApproveAsync(id);
        return View(await houseService.GetAllForApprovalAsync());
    }
}