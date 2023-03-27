namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    [Key]
    public int Id { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public string? Name { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [Required]
    public Category Category { get; set; } = null!;

    public decimal Price { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}