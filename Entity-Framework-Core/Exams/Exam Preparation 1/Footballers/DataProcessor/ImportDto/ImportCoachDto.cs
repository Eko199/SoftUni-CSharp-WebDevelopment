namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Coach")]
public class ImportCoachDto
{
    [XmlElement("Name")]
    [StringLength(40, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = null!;

    [XmlElement("Nationality")]
    [Required(AllowEmptyStrings = false)]
    public string Nationality { get; set; } = null!;

    [XmlArray("Footballers")]
    public ImportFootballerDto[]? Footballers { get; set; }
}