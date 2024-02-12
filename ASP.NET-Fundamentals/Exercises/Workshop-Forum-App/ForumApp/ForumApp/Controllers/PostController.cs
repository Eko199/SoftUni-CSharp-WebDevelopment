namespace ForumApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Core.Contracts;
using Core.Models;

public class PostController : Controller
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> Index() => View(await postService.GetAllAsync());

    [HttpGet]
    public IActionResult Add() => View(new PostModel());

    [HttpPost]
    public async Task<IActionResult> Add(PostModel post)
    {
        if (!ModelState.IsValid)
        {
            return View(post);
        }

        await postService.AddAsync(post);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        PostModel? post = await postService.FindByIdAsync(id);

        if (post is null)
        {
            ModelState.AddModelError("All", "Invalid post!");
        }

        return View(post);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, PostModel post)
    {
        if (!ModelState.IsValid || id != post.Id)
        {
            return View(post);
        }

        await postService.EditAsync(post);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await postService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}