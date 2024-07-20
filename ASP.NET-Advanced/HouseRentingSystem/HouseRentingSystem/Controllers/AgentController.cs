namespace HouseRentingSystem.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Agent;

[Authorize]
public class AgentController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Become()
    {
        return View(new BecomeAgentFormModel());
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel agent)
    {
        return RedirectToAction(nameof(HouseController.All), "House");
    }
}