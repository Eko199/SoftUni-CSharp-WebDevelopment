namespace HouseRentingSystem.Controllers;

using System.Security.Claims;
using Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Agent;
using Core.Services.Contracts.Agent;

public class AgentController : BaseController
{
    private readonly IAgentService agentService;

    public AgentController(IAgentService agentService)
    {
        this.agentService = agentService;
    }

    [HttpGet]
    [NotAnAgent]
    public IActionResult Become() => View(new BecomeAgentFormModel());

    [HttpPost]
    [NotAnAgent]
    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        var userId = User.Id()!;

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