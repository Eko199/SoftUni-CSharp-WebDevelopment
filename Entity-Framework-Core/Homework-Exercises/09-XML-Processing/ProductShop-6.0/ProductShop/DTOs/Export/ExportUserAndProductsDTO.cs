﻿namespace ProductShop.DTOs.Export;

using System.Xml.Serialization;

[XmlType("User")]
public class ExportUserAndProductsDTO
{
    [XmlElement("firstName")]
    public string FirstName { get; set; } = null!;

    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlElement("age")]
    public int? Age { get; set; }

    [XmlElement("SoldProducts")]
    public ExportSoldProductsDTO SoldProducts { get; set; } = null!;
}