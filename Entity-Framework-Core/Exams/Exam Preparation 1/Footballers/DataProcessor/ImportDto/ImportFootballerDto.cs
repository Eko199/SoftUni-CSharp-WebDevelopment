namespace Footballers.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Footballer")]
public class ImportFootballerDto
{
    [XmlElement("Name")]
    [StringLength(40, MinimumLength = 2)]
    [Required(AllowEmptyStrings = false)]
    public string Name { get; set; } = null!;

    [XmlElement("ContractStartDate")]
    [Required(AllowEmptyStrings = false)]
    public string ContractStartDate { get; set; } = null!;

    [XmlElement("ContractEndDate")]
    [Required(AllowEmptyStrings = false)]
    public string ContractEndDate { get; set; } = null!;

    [XmlElement("BestSkillType")]
    public int BestSkillType { get; set; }

    [XmlElement("PositionType")]
    public int PositionType { get; set; }
}