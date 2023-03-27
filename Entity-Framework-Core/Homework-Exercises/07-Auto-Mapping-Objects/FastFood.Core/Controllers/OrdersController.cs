namespace FastFood.Core.Controllers;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;

using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels.Orders;

public class OrdersController : Controller
{
    private readonly FastFoodContext _context;
    private readonly IMapper _mapper;

    public OrdersController(FastFoodContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Create()
    {
        var viewOrder = new CreateOrderViewModel
        {
            Items = await _context.Items.Select(x => x.Id).ToListAsync(),
            Employees = await _context.Employees.Select(x => x.Id).ToListAsync(),
        };

        return View(viewOrder);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderInputModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Error", "Home");

        Order order = _mapper.Map<Order>(model);
        await _context.Orders.AddAsync(order);

        var orderItem = new OrderItem
        {
            Order = order,
            ItemId = model.ItemId,
            Quantity = model.Quantity
        };

        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();

        return RedirectToAction("All", "Orders");
    }

    public async Task<IActionResult> All()
    {
        IList<OrderAllViewModel> orders = await _context.Orders
            .ProjectTo<OrderAllViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return View(orders);
    }
}