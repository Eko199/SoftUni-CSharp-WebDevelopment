namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlRoot("Users")]
public class ExportUsersDTO
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("users")]
    public ExportUserAndProductsDTO[] Users { get; set; } = null!;
}