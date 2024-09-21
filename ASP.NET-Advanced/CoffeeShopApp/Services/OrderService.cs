namespace CoffeeShopApp.Services;

using Models;

public class OrderService : IOrderService
{
    private readonly string[] status =
    [
        "Grinding beans",
        "Steaming milk",
        "Quality control",
        "Delivering",
        "Picked up"
    ];

    private readonly Random random = new();

    private readonly IList<int> indexes = new List<int>();

    public CheckResult GetUpdate(int orderId)
    {
        Thread.Sleep(1000);
        int index = indexes[orderId - 1];

        if (random.Next(0, 4) != 2 || status.Length <= index)
        {
            return new CheckResult { New = false };
        }

        indexes[orderId - 1]++;

        return new CheckResult
        {
            New = true,
            Update = status[index],
            Finished = status.Length - 1 == index
        };
    }

    public int NewOrder()
    {
        indexes.Add(0);
        return indexes.Count;
    }
}