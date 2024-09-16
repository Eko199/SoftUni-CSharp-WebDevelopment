namespace HouseRentingSystem.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Attributes;
using static Common.MessageConstants;
using Core.Models.Agent;
using Core.Services.Contracts.Agent;
using Core.Services.Contracts.ApplicationUser;

public class AgentController(IAgentService agentService, IApplicationUserService userService) : BaseController
{
    [HttpGet]
    [NotAnAgent]
    public IActionResult Become() => View(new BecomeAgentFormModel());

    [HttpPost]
    [NotAnAgent]
    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        var userId = User.Id()!;

        if (await agentService.AgentWithPhoneNumberExistsAsync(agent.PhoneNumber))
        {
            ModelState.AddModelError(nameof(agent.PhoneNumber), "Phone number already exists. Enter another one.");
        }

        if (await userService.UserHasRentsAsync(userId))
        {
            ModelState.AddModelError("Error", "You should have no rents to become ana agent!");
        }

        if (!ModelState.IsValid)
        {
            return View(agent);
        }

        await agentService.CreateAsync(userId, agent);
        TempData[SuccessMessage] = "You have successfully become an agent";

        return RedirectToAction(nameof(HouseController.All), "House");
    }
}