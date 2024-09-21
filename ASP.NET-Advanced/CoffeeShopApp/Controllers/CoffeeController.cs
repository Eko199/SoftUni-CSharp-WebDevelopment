namespace CoffeeShopApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Hubs;
using Models;
using Services;

public class CoffeeController(IOrderService orders, IHubContext<CoffeeHub> coffeeHub) : Controller
{
    [HttpPost]
    public async Task<IActionResult> OrderCoffee([FromBody] Order order)
    {
        await coffeeHub.Clients.All.SendAsync("NewOrder", order);
        int orderId = orders.NewOrder();
        return Accepted(orderId);
    }
}