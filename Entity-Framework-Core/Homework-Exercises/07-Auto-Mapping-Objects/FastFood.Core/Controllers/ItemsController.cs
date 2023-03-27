namespace FastFood.Core.Controllers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels.Items;

public class ItemsController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public ItemsController(FastFoodContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        IList<CreateItemViewModel> categories = await _context.Categories
            .ProjectTo<CreateItemViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(categories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateItemInputModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Error", "Home");

        await _context.Items.AddAsync(_mapper.Map<Item>(model));
        await _context.SaveChangesAsync();

        return RedirectToAction("All", "Items");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IList<ItemsAllViewModels> items = await _context.Items
            .ProjectTo<ItemsAllViewModels>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(items);
    }
}