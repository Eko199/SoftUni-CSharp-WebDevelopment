﻿namespace ProductShop.DTOs.Import;

using System.Xml.Serialization;

[XmlType("Category")]
public class ImportCategoryDTO
{
    [XmlElement("name")]
    public string? Name { get; set; }
}