namespace FastFood.Core.ViewModels.Orders;

public class OrderAllViewModel
{
    public int OrderId { get; set; }

    public string Customer { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string DateTime { get; set; }
}