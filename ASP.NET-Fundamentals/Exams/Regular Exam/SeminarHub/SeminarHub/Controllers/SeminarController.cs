namespace SeminarHub.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Seminar;
using Services.Contracts;

[Authorize]
public class SeminarController : Controller
{
    private readonly ICategoryService categoryService;
    private readonly ISeminarService seminarService;

    public SeminarController(ICategoryService categoryService, ISeminarService seminarService)
    {
        this.categoryService = categoryService;
        this.seminarService = seminarService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
        => View(await seminarService.GetAllAsync());

    [HttpGet]
    public async Task<IActionResult> Joined()
        => View(await seminarService.GetAllJoinedAsync(GetUserId()));

    [HttpGet]
    public async Task<IActionResult> Add()
        => View(new SeminarFormModel
        {
            Categories = await categoryService.GetAllAsync()
        });

    [HttpPost]
    public async Task<IActionResult> Add(SeminarFormModel seminar)
    {
        var categories = (await categoryService.GetAllAsync()).ToArray();

        if (categories.All(c => c.Id != seminar.CategoryId))
        {
            ModelState.AddModelError(nameof(seminar.CategoryId), "No such category found!");
        }

        if (!ModelState.IsValid)
        {
            seminar.Categories = categories;
            return View(seminar);
        }

        seminar.OrganiserId = GetUserId();
        await seminarService.AddAsync(seminar);
        return RedirectToAction(nameof(All));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var seminar = await seminarService.GetFormModelByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        if (seminar.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        seminar.Categories = await categoryService.GetAllAsync();
        return View(seminar);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, SeminarFormModel seminar)
    {
        //We need this model for some validations
        var seminarModel = await seminarService.GetFormModelByIdAsync(id);

        if (seminarModel == null)
        {
            return BadRequest();
        }

        if (seminarModel.OrganiserId != GetUserId())
        {
            return Unauthorized();
        }

        var categories = (await categoryService.GetAllAsync()).ToArray();

        if (categories.All(c => c.Id != seminar.CategoryId))
        {
            ModelState.AddModelError(nameof(seminar.CategoryId), "No such category found!");
        }

        if (!ModelState.IsValid)
        {
            seminar.Categories = categories;
            return View(seminar);
        }

        try
        {
            await seminarService.EditAsync(id, seminar);
        }
        catch (ApplicationException)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var seminar = await seminarService.GetDetailsByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        bool successful = await seminarService.JoinAsync(id, GetUserId());
        return RedirectToAction(successful ? nameof(Joined) : nameof(All));
    }

    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var seminar = await seminarService.GetDetailsByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        await seminarService.LeaveAsync(id, GetUserId());
        return RedirectToAction(nameof(Joined));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var seminar = await seminarService.GetDetailsByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        return View(seminar);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var seminar = await seminarService.GetDeleteModelByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        if (seminar.OrganizerId != GetUserId())
        {
            return Unauthorized();
        }

        return View(seminar);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        //We need this model for some validations
        var seminar = await seminarService.GetDeleteModelByIdAsync(id);

        if (seminar == null)
        {
            return BadRequest();
        }

        if (seminar.OrganizerId != GetUserId())
        {
            return Unauthorized();
        }

        try
        {
            await seminarService.DeleteAsync(id);
        }
        catch (ApplicationException)
        {
            return BadRequest();
        }

        return RedirectToAction(nameof(All));
    }

    private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
}