namespace CarDealer.Utilities;

using System.Text;
using System.Xml.Serialization;

public static class XmlHelper
{
    public static T Deserialize<T>(string xml, string rootElementName)
    {
        var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootElementName));
        using var reader = new StringReader(xml);

        return (T)serializer.Deserialize(reader)!;
    }

    public static string Serialize<T>(T element, string rootElementName)
    {
        var sb = new StringBuilder();

        var root = new XmlRootAttribute(rootElementName);
        var serializer = new XmlSerializer(typeof(T), root);
        var namespaces = new XmlSerializerNamespaces();

        namespaces.Add(string.Empty, string.Empty);

        using var writer = new StringWriter(sb);
        serializer.Serialize(writer, element, namespaces);

        return sb.ToString();
    }

    public static string SerializeRootIncluded<T>(T element)
    {
        var sb = new StringBuilder();
        
        var serializer = new XmlSerializer(typeof(T));
        var namespaces = new XmlSerializerNamespaces();

        namespaces.Add(string.Empty, string.Empty);

        using var writer = new StringWriter(sb);
        serializer.Serialize(writer, element, namespaces);

        return sb.ToString();
    }
}