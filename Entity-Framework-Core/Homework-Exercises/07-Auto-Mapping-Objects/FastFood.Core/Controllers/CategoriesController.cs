namespace FastFood.Core.Controllers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels.Categories;

public class CategoriesController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public CategoriesController(FastFoodContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryInputModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Error", "Home");

        await _context.Categories.AddAsync(_mapper.Map<Category>(model));
        await _context.SaveChangesAsync();

        return RedirectToAction("All", "Categories");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IList<CategoryAllViewModel> categories = await _context.Categories
            .ProjectTo<CategoryAllViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(categories);
    }
}