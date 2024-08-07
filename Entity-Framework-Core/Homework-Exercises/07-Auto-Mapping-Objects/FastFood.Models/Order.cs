﻿namespace FastFood.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Customer { get; set; } = null!;

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public OrderType Type { get; set; }

    [NotMapped]
    public decimal TotalPrice { get; set; }

    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }

    [Required]
    public Employee Employee { get; set; } = null!;

    public ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
}