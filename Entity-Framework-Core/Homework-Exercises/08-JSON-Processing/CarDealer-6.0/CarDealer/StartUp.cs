namespace CarDealer;

using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Data;
using DTOs.Import;
using Models;

public class StartUp
{
    public static void Main()
    {
        using var context = new CarDealerContext();
        string json = GetSalesWithAppliedDiscount(context);

        Console.WriteLine(json);
        File.WriteAllText("../../../Results/sales-discounts.json", json);
    }

    //Problem 09.
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        var supplierDTOs = JsonConvert.DeserializeObject<ImportSupplierDTO[]>(inputJson);
        var suppliers = CreateMapper().Map<Supplier[]>(supplierDTOs);

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}.";
    }

    //Problem 10.
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        var partDTOs = JsonConvert.DeserializeObject<ImportPartDTO[]>(inputJson);
        var parts = CreateMapper().Map<Part[]>(partDTOs!
            .Where(p => context.Suppliers
                .Any(s => s.Id == p.SupplierId)));

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}.";
    }

    //Problem 11.
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var carDTOs = JsonConvert.DeserializeObject<ImportCarDTO[]>(inputJson);
        var partCars = new HashSet<PartCar>();

        foreach (ImportCarDTO carDTO in carDTOs!)
        {
            var car = new Car
            {
                Make = carDTO.Make,
                Model = carDTO.Model,
                TraveledDistance = carDTO.TraveledDistance
            };

            foreach (int partId in carDTO.PartsId.Distinct())
            {
                partCars.Add(new PartCar 
                {
                    PartId = partId,
                    Car = car
                });
            }
        }
        
        context.PartsCars.AddRange(partCars);
        context.SaveChanges();

        return $"Successfully imported {carDTOs.Length}.";
    }

    //Problem 12.
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        var customerDTO = JsonConvert.DeserializeObject<ImportCustomerDTO[]>(inputJson);
        var customers = CreateMapper().Map<Customer[]>(customerDTO);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}.";
    }

    //Problem 13.
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        var saleDTOs = JsonConvert.DeserializeObject<ImportSaleDTO[]>(inputJson);
        var sales = CreateMapper().Map<Sale[]>(saleDTOs);

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Length}.";
    }

    //Problem 14.
    public static string GetOrderedCustomers(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                c.IsYoungDriver
            })
            .ToArray(), Formatting.Indented);

    //Problem 15.
    public static string GetCarsFromMakeToyota(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Cars
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .ToArray(), Formatting.Indented);

    //Problem 16.
    public static string GetLocalSuppliers(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Suppliers
            .Where(s => !s.IsImporter)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray(), Formatting.Indented);

    //Problem 17.
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Cars
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                parts = c.PartsCars
                    .Select(pc => new
                    {
                        pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    })
            })
            .ToArray(), Formatting.Indented);

    //Problem 18.
    public static string GetTotalSalesByCustomer(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales.SelectMany(s => s.Car.PartsCars, (sale, partCar) => partCar.Part.Price).Sum()
            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray(), Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

    //Problem 19.
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        => JsonConvert.SerializeObject(context.Sales
            .Take(10)
            .Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = s.Discount.ToString("F2"),
                price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("F2"),
                priceWithDiscount = ((1 - s.Discount / 100) * s.Car.PartsCars.Sum(pc => pc.Part.Price)).ToString("F2")
            })
            .ToArray(), Formatting.Indented);

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg 
            => cfg.AddProfile(new CarDealerProfile())));
}