namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;

public class ImportSellerDto
{

    [StringLength(20, MinimumLength = 5)]
    public string Name { get; set; } = null!;

    [StringLength(30, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string Address { get; set; } = null!;

    [Required(AllowEmptyStrings = false)]
    public string Country { get; set; } = null!;

    [RegularExpression(@"^www\.[a-zA-Z0-9\-]+\.com$")]
    [Required(AllowEmptyStrings = false)]
    public string Website { get; set; } = null!;

    public ICollection<int>? Boardgames { get; set; }
}