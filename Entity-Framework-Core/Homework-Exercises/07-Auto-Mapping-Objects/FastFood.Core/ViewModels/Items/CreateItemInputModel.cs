﻿namespace FastFood.Core.ViewModels.Items;

using System.ComponentModel.DataAnnotations;

public class CreateItemInputModel
{
    public string Name { get; set; }

    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}