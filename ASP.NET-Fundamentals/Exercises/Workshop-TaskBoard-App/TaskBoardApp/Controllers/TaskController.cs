namespace TaskBoardApp.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using TaskBoardApp.Models.Task;

[Authorize]
public class TaskController : Controller
{
    private readonly IBoardService boardService;
    private readonly ITaskService taskService;

    public TaskController(IBoardService boardService, ITaskService taskService)
    {
        this.boardService = boardService;
        this.taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
        => View(new TaskFormModel
        {
            Boards = await boardService.GetAllForSelectAsync()
        });

    [HttpPost]
    public async Task<IActionResult> Create(TaskFormModel model)
    {
        var boards = (await boardService.GetAllForSelectAsync()).ToArray();

        if (boards.All(b => b.Id != model.BoardId))
        {
            ModelState.AddModelError(nameof(model.BoardId), "Board does not exist!");
        }

        if (!ModelState.IsValid)
        {
            model.Boards = boards;
            return View(model);
        }

        await taskService.AddAsync(model, User.FindFirstValue(ClaimTypes.NameIdentifier));
        return RedirectToAction(nameof(Index), "Board");
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        TaskDetailsViewModel? task = await taskService.GetDetailsByIdAsync(id);

        if (task is null)
        {
            return BadRequest();
        }

        return View(task);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var task = await taskService.GetEditByIdAsync(id);

        if (task is null)
        {
            return BadRequest();
        }

        if (task.OwnerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return Unauthorized();
        }

        task.Boards = await boardService.GetAllForSelectAsync();
        return View(task);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, TaskFormModel model)
    {
        var task = await taskService.GetEditByIdAsync(id);

        if (task is null)
        {
            return BadRequest();
        }

        if (task.OwnerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return Unauthorized();
        }

        var boards = (await boardService.GetAllForSelectAsync()).ToArray();

        if (boards.All(b => b.Id != task.BoardId))
        {
            ModelState.AddModelError(nameof(task.BoardId), "Board does not exist!");
        }

        if (!ModelState.IsValid || id != model.Id)
        {
            task.Boards = boards;
            return View(task);
        }
        
        await taskService.EditAsync(model);
        return RedirectToAction(nameof(Index), "Board");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await taskService.GetEditByIdAsync(id);

        if (task is null)
        {
            return BadRequest();
        }

        if (task.OwnerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return Unauthorized();
        }

        return View(new TaskViewModel
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description
        });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(TaskViewModel model)
    {
        var task = await taskService.GetEditByIdAsync(model.Id);

        if (task is null)
        {
            return BadRequest();
        }

        if (task.OwnerId != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return Unauthorized();
        }

        await taskService.DeleteAsync(model.Id);

        return RedirectToAction(nameof(Index), "Board");
    }
}