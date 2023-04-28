namespace Trucks.DataProcessor;

using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using ExportDto;

public class Serializer
{
    public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
    {
        var root = new XmlRootAttribute("Despatchers");
        var serializer = new XmlSerializer(typeof(ExportDespatcherDto[]), root);

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using var writer = new StringWriter();

        serializer.Serialize(writer, context.Despatchers
            .Where(d => d.Trucks.Any())
            .OrderByDescending(d => d.Trucks.Count)
            .ThenBy(d => d.Name)
            .ToArray()
            .Select(d => new ExportDespatcherDto
            {
                TrucksCount = d.Trucks.Count,
                DespatcherName = d.Name,
                Trucks = d.Trucks
                    .Select(t => new ExportTruckDto
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
            })
            .ToArray(), namespaces);

        return writer.ToString();
    }

    public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        => JsonConvert.SerializeObject(context.Clients
            .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
            .OrderByDescending(c => c.ClientsTrucks.Count(ct => ct.Truck.TankCapacity >= capacity))
            .ThenBy(c => c.Name)
            .Take(10)
            .ToArray()
            .Select(c => new
            {
                c.Name,
                Trucks = c.ClientsTrucks
                    .Where(ct => ct.Truck.TankCapacity >= capacity)
                    .Select(ct => new
                    {
                        TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                        ct.Truck.VinNumber,
                        ct.Truck.TankCapacity,
                        ct.Truck.CargoCapacity,
                        CategoryType = ct.Truck.CategoryType.ToString(),
                        MakeType = ct.Truck.MakeType.ToString(),
                    })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
            }), Formatting.Indented);
}