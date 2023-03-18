namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public Customer()
    {
        Sales = new HashSet<Sale>();
    }

    [Key]
    public int CustomerId { get; set; }

    [MaxLength(100)] 
    [Unicode] 
    public string Name { get; set; } = null!;

    [MaxLength(80)]
    [Unicode]
    public string Email { get; set; } = null!;

    public string? CreditCardNumber { get; set; }

    public ICollection<Sale> Sales { get; set; }
}