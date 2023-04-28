namespace Trucks.DataProcessor;

using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using Data;
using Data.Models;
using Data.Models.Enums;
using ImportDto;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedDespatcher
        = "Successfully imported despatcher - {0} with {1} trucks.";

    private const string SuccessfullyImportedClient
        = "Successfully imported client - {0} with {1} trucks.";

    public static string ImportDespatcher(TrucksContext context, string xmlString)
    {
        var root = new XmlRootAttribute("Despatchers");
        var serializer = new XmlSerializer(typeof(ImportDespatcherDto[]), root);

        using var reader = new StringReader(xmlString);
        var despatcherDtos = (ImportDespatcherDto[])serializer.Deserialize(reader)!;

        var despatchers = new List<Despatcher>(despatcherDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportDespatcherDto despatcherDto in despatcherDtos)
        {
            if (!IsValid(despatcherDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var trucks = new List<Truck>(despatcherDto.Trucks.Length);

            foreach (ImportTruckDto truckDto in despatcherDto.Trucks)
            {
                if (!IsValid(truckDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                trucks.Add(new Truck
                {
                    RegistrationNumber = truckDto.RegistrationNumber,
                    VinNumber = truckDto.VinNumber,
                    TankCapacity = truckDto.TankCapacity,
                    CargoCapacity = truckDto.CargoCapacity,
                    CategoryType = (CategoryType)truckDto.CategoryType,
                    MakeType = (MakeType)truckDto.MakeType
                });
            }

            despatchers.Add(new Despatcher
            {
                Name = despatcherDto.Name,
                Position = despatcherDto.Position,
                Trucks = trucks
            });

            sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcherDto.Name, trucks.Count));
        }

        context.Despatchers.AddRange(despatchers);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    } 

    public static string ImportClient(TrucksContext context, string jsonString)
    {
        ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString)!;

        var clients = new List<Client>(clientDtos.Length);
        var sb = new StringBuilder();

        foreach (ImportClientDto clientDto in clientDtos)
        {
            if (!IsValid(clientDto) || clientDto.Type == "usual")
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var clientTrucks = new List<ClientTruck>(clientDto.Trucks.Length);

            foreach (int truckId in clientDto.Trucks.Distinct())
            {
                if (context.Trucks.Find(truckId) == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                clientTrucks.Add(new ClientTruck
                {
                    TruckId = truckId
                });
            }

            clients.Add(new Client
            {
                Name = clientDto.Name,
                Nationality = clientDto.Nationality,
                Type = clientDto.Type,
                ClientsTrucks = clientTrucks
            });

            sb.AppendLine(string.Format(SuccessfullyImportedClient, clientDto.Name, clientTrucks.Count));
        }

        context.Clients.AddRange(clients);
        context.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}