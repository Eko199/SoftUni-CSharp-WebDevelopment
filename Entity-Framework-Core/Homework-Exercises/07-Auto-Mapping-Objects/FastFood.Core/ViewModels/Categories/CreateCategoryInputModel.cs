﻿using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Categories;

public class CreateCategoryInputModel
{
    [StringLength(30, MinimumLength = 3)]
    public string CategoryName { get; set; }
}