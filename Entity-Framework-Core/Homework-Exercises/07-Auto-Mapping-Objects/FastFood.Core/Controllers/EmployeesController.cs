namespace FastFood.Core.Controllers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels.Employees;

public class EmployeesController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public EmployeesController(FastFoodContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        IList<RegisterEmployeeViewModel> positions = await _context.Positions
            .ProjectTo<RegisterEmployeeViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(positions);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Error", "Home");

        await _context.AddAsync(_mapper.Map<Employee>(model));
        await _context.SaveChangesAsync();

        return RedirectToAction("All", "Employees");
    }

    public async Task<IActionResult> All()
    {
        IList<EmployeesAllViewModel> employees = await _context.Employees
            .ProjectTo<EmployeesAllViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(employees);
    }
}