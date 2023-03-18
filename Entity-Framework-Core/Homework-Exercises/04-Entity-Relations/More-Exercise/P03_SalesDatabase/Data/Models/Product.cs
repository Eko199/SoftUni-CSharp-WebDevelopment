namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

public class Product
{
    public Product()
    {
        Sales = new HashSet<Sale>();
    }

    [Key]
    public int ProductId { get; set; }

    [MaxLength(50)]
    [Unicode]
    public string Name { get; set; } = null!;

    public double Quantity { get; set; }

    public decimal Price { get; set; }

    public ICollection<Sale> Sales { get; set; }
}