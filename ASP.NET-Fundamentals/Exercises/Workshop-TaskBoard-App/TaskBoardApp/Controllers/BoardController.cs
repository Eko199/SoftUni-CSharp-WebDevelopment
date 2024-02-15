namespace TaskBoardApp.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

[Authorize]
public class BoardController : Controller
{
    private readonly IBoardService boardService;

    public BoardController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index() => View(await boardService.GetAllAsync());
}