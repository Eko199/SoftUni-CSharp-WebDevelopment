namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class ImportTeamDto
{
    [StringLength(40, MinimumLength = 3)]
    [Required(AllowEmptyStrings = false)]
    [RegularExpression(@"^[a-zA-Z\d\s\.\-]+$")]
    public string Name { get; set; } = null!;

    [StringLength(40, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string Nationality { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    public string Trophies { get; set; } = null!;

    public ICollection<int>? Footballers { get; set; }
}