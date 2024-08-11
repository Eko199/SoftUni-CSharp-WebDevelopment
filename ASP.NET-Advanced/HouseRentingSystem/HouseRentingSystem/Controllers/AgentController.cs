namespace HouseRentingSystem.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Agent;
using Core.Services.Contracts.Agent;

[Authorize]
public class AgentController : Controller
{
    private readonly IAgentService agentService;

    public AgentController(IAgentService agentService)
    {
        this.agentService = agentService;
    }

    [HttpGet]
    public async Task<IActionResult> Become()
    {
        if (await agentService.ExistsByIdAsync(User.Id()!))
        {
            return BadRequest();
        }

        return View(new BecomeAgentFormModel());
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        var userId = User.Id()!;

        if (await agentService.ExistsByIdAsync(userId))
        {
            return BadRequest();
        }

        if (await agentService.UserWithPhoneNumberExistsAsync(agent.PhoneNumber))
        {
            ModelState.AddModelError(nameof(agent.PhoneNumber), "Phone number already exists. Enter another one.");
        }

        if (await agentService.UserHasRentsAsync(userId))
        {
            ModelState.AddModelError("Error", "You should have no rents to become ana agent!");
        }

        if (!ModelState.IsValid)
        {
            return View(agent);
        }

        await agentService.CreateAsync(userId, agent);
        return RedirectToAction(nameof(HouseController.All), "House");
    }
}