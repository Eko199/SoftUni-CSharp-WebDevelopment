namespace Trucks.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Despatcher")]
public class ImportDespatcherDto
{
    [XmlElement("Name")]
    [Required]
    [StringLength(40, MinimumLength = 2)]
    public string Name { get; set; } = null!;

    [XmlElement("Position")]
    [Required(AllowEmptyStrings = false)]
    public string Position { get; set; } = null!;

    [XmlArray("Trucks")]
    public ImportTruckDto[] Trucks { get; set; } = null!;
}