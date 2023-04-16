namespace Blog.Web.Controllers;

using System.Text;

using Microsoft.AspNetCore.Mvc;

using Core.Models.Article;
using Core.Services.Contracts;

public class ArticleController : Controller
{
    private readonly ICategoryService categoryService;
    private readonly IArticleService articleService;

    public ArticleController(ICategoryService categoryService, IArticleService articleService)
    {
        this.categoryService = categoryService;
        this.articleService = articleService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var articles = await articleService.GetAllAsync();

        return View(articles);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        if (HttpContext.Session.Get("userId") == null)
        {
            ModelState.AddModelError("", "Please log in!");
            return RedirectToAction("Login", "ApplicationUser");
        }

        var addModel = new ArticleAddViewModel
        {
            Categories = await categoryService.GetAllAsync()
        };

        return View(addModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ArticleAddViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid article fields!");
            return View(model);
        }

        byte[]? userIdBytes = HttpContext.Session.Get("userId");

        if (userIdBytes == null)
        {
            ModelState.AddModelError("", "Please log in!");
            return RedirectToAction("Login", "ApplicationUser");
        }

        model.AuthorId = Encoding.UTF8.GetString(userIdBytes);
        model.CreatedOn = DateTime.Now;

        await articleService.AddAsync(model);
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ArticleViewModel? article = await articleService.GetByIdAsync(id);

        if (article == null)
        {
            ModelState.AddModelError("ArticleId", "Invalid article id!");
            return RedirectToAction("All");
        }

        return View(article);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        ArticleEditViewModel? article = await articleService.GetByIdForEditAsync(id);

        if (article == null)
        {
            ModelState.AddModelError("ArticleId", "Invalid article id!");
            return RedirectToAction("All");
        }

        if (HttpContext.Session.Get("userId") == null)
        {
            ModelState.AddModelError("", "Please log in!");
            return RedirectToAction("Login", "ApplicationUser");
        }
            
        return View(article);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ArticleEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Invalid article fields!");
            return View();
        }

        if (HttpContext.Session.Get("userId") == null)
        {
            ModelState.AddModelError("", "Please log in!");
            return RedirectToAction("Login", "ApplicationUser");
        }

        await articleService.UpdateAsync(model);

        return RedirectToAction("All");
    }
}