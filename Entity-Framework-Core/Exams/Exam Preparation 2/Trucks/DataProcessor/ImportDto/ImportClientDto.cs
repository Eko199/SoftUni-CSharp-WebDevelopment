namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class ImportClientDto
{
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string Nationality { get; set; } = null!;

    [Required]
    public string Type { get; set; } = null!;

    public int[] Trucks { get; set; } = null!;
}