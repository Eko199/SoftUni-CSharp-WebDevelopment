namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = null!;

    [Required]
    public int Age { get; set; }

    [Required]
    [MaxLength(30)]
    public string Address { get; set; } = null!;

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    [Required]
    public Position Position { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>(); 
}