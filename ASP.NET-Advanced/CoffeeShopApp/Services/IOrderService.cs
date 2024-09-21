namespace CoffeeShopApp.Services;

using Models;

public interface IOrderService
{
    public CheckResult GetUpdate(int orderId);

    public int NewOrder();
}