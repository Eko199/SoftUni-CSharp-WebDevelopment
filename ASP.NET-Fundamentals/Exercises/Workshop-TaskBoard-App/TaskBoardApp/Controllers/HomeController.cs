namespace TaskBoardApp.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

public class HomeController : Controller
{
    private readonly IBoardService boardService;

    public HomeController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    public async Task<IActionResult> Index()
    {
        var model = await boardService.GetHomeViewModelAsync(User.Identity?.IsAuthenticated == true
            ? User.FindFirstValue(ClaimTypes.NameIdentifier)
            : null);

        return View(model);
    }
}