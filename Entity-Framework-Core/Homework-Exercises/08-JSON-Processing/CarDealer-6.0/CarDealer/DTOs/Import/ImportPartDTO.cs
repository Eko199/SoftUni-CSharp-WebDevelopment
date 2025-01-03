﻿namespace CarDealer.DTOs.Import;

public class ImportPartDTO
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int SupplierId { get; set; }
}