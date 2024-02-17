namespace Homies.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

[Authorize]
public class EventController : Controller
{
    private readonly ITypeService typeService;
    private readonly IEventService eventService;

    public EventController(ITypeService typeService, IEventService eventService)
    {
        this.eventService = eventService;
        this.typeService = typeService;
    }

    [HttpGet]
    public async Task<IActionResult> All() 
        => View(await eventService.GetAllAsync());

    [HttpGet]
    public async Task<IActionResult> Joined()
        => View(await eventService.GetAllJoinedAsync(GetUserId()));

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        if (await eventService.GetDetailsByIdAsync(id) is null)
        {
            return BadRequest();
        }

        bool success = await eventService.JoinAsync(GetUserId(), id);
        return RedirectToAction(success ? nameof(Joined) : nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        if (await eventService.GetDetailsByIdAsync(id) is null 
            || !await eventService.LeaveAsync(GetUserId(), id))
        {
            return BadRequest();
        }
        
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Add() 
        => View(new EventFormViewModel
        {
            Types = await typeService.GetAllAsync()
        });

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        var types = (await typeService.GetAllAsync()).ToArray();

        if (types.All(t => t.Id != model.TypeId))
        {
            ModelState.AddModelError(nameof(model.TypeId), "No such type found!");
        }

        if (!ModelState.IsValid)
        {
            model.Types = types;
            return View(model);
        }

        await eventService.AddAsync(model, GetUserId());
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var model = await eventService.GetFormModelByIdAsync(id);

        if (model is null)
        {
            return BadRequest();
        }

        if (model.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        model.Types = await typeService.GetAllAsync();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventFormViewModel model)
    {
        var types = (await typeService.GetAllAsync()).ToArray();

        if (types.All(t => t.Id != model.TypeId))
        {
            ModelState.AddModelError(nameof(model.TypeId), "No such type found!");
        }

        if (!ModelState.IsValid)
        {
            model.Types = types;
            return View(model);
        }

        await eventService.EditAsync(id, model);
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var model = await eventService.GetDetailsByIdAsync(id);

        if (model is null)
        {
            return BadRequest();
        }

        return View(model);
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}