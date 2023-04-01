namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Creator")]
public class ImportCreatorDto
{
    [XmlElement("FirstName")]
    [StringLength(7, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string FirstName { get; set; } = null!;

    [XmlElement("LastName")]
    [StringLength(7, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string LastName { get; set; } = null!;

    [XmlArray("Boardgames")]
    public ImportBoardgameDto[]? Boardgames { get; set; }
}