namespace Boardgames.DataProcessor.ImportDto;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

[XmlType("Boardgame")]
public class ImportBoardgameDto
{
    [XmlElement("Name")]
    [StringLength(20, MinimumLength = 10)]
    public string Name { get; set; } = null!;

    [XmlElement("Rating")]
    [Range(1, 10.00)]
    public double Rating { get; set; }

    [XmlElement("YearPublished")]
    [Range(2018, 2023)]
    public int YearPublished { get; set; }

    [XmlElement("CategoryType")]
    [Range(0, 4)]
    public int CategoryType { get; set; }

    [XmlElement("Mechanics")]
    public string Mechanics { get; set; } = null!;
}