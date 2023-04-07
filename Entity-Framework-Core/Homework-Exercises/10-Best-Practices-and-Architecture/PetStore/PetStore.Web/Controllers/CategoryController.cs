namespace PetStore.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using Data.Models;
using Services.Data;
using Services.Data.Models;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        await _categoryService.AddCategoryAsync(category);
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();

        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        CategoryViewModel category = await _categoryService.GetCategoryByIdAsync(id);

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryViewModel category)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Error", "Home");
        }

        await _categoryService.UpdateCategoryAsync(category);

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return RedirectToAction("All");
    }
}