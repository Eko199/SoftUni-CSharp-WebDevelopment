﻿namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        CategoriesProducts = new List<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<CategoryProduct> CategoriesProducts { get; set; }
}