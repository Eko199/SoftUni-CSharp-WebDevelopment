namespace FastFood.Core.Controllers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using ViewModels.Positions;

public class PositionsController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public PositionsController(FastFoodContext context, IMapper mapper)
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
    public async Task<IActionResult> Create(CreatePositionInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Error", "Home");
        }

        Position? position = _mapper.Map<Position>(model);

        await _context.Positions.AddAsync(position);

        await _context.SaveChangesAsync();

        return RedirectToAction("All", "Positions");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var positions = await _context.Positions
            .ProjectTo<PositionsAllViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(positions);
    }
}