namespace CoffeeShopApp.Hubs;

using Microsoft.AspNetCore.SignalR;
using Models;
using Services;

public class CoffeeHub(IOrderService orderService) : Hub
{
    public async Task GetUpdateForOrder(int orderId)
    {
        CheckResult result;

        do
        {
            result = orderService.GetUpdate(orderId);

            if (result.New)
            {
                await Clients.Caller.SendAsync("ReceiveOrderUpdate", result.Update);
            }
        }
        while (!result.Finished);

        await Clients.Caller.SendAsync("Finished");
    }
}