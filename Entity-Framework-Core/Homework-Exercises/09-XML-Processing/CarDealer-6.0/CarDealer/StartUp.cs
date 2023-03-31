namespace CarDealer;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Data;
using DTOs.Export;
using DTOs.Import;
using Microsoft.EntityFrameworkCore;
using Models;
using Utilities;

public class StartUp
{
    public static void Main()
    {
        using var context = new CarDealerContext();
        string xml = GetSalesWithAppliedDiscount(context);

        Console.WriteLine(xml);
        File.WriteAllText("../../../Results/sales-discounts.xml", xml);
    }

    //Problem 09.
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        ImportSupplierDTO[] supplierDTOs = XmlHelper.Deserialize<ImportSupplierDTO[]>(inputXml, "Suppliers");
        Supplier[] suppliers = CreateMapper().Map<Supplier[]>(supplierDTOs);

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    //Problem 10.
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        ImportPartDTO[] partDTOs = XmlHelper.Deserialize<ImportPartDTO[]>(inputXml, "Parts");
        Part[] parts = CreateMapper().Map<Part[]>(partDTOs
            .Where(p => context.Suppliers
                .Any(s => s.Id == p.SupplierId)));

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}";
    }

    //Problem 11.
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        ImportCarDTO[] carDTOs = XmlHelper.Deserialize<ImportCarDTO[]>(inputXml, "Cars");
        Car[] cars = carDTOs.Select(c => new Car 
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                PartsCars = c.Parts
                    .DistinctBy(p => p.Id)
                    .Where(p => context.Parts.Any(part => part.Id == p.Id))
                    .Select(p => new PartCar
                    {
                        PartId = p.Id
                    })
                    .ToHashSet()
            })
            .ToArray();

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Length}";
    }

    //Problem 12.
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        ImportCustomerDTO[] customerDTOs = XmlHelper.Deserialize<ImportCustomerDTO[]>(inputXml, "Customers");
        Customer[] customers = CreateMapper().Map<Customer[]>(customerDTOs);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }

    //Problem 13.
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        ImportSaleDTO[] saleDTOs = XmlHelper.Deserialize<ImportSaleDTO[]>(inputXml, "Sales");
        Sale[] sales = CreateMapper().Map<Sale[]>(saleDTOs
            .Where(s => context.Cars.Any(c => c.Id == s.CarId)));

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Length}";
    }

    //Problem 14.
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        ExportCarWithDistanceDTO[] cars = context.Cars
            .Where(c => c.TraveledDistance > 2_000_000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<ExportCarWithDistanceDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(cars, "cars");
    }

    //Problem 15.
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        ExportCarFromMakeDTO[] cars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ProjectTo<ExportCarFromMakeDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(cars, "cars");
    }

    //Problem 16.
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        ExportLocalSupplierDTO[] suppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .ProjectTo<ExportLocalSupplierDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(suppliers, "suppliers");
    }

    //Problem 17.
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        ExportCarWithPartsDTO[] cars = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ProjectTo<ExportCarWithPartsDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(cars, "cars");
    }

    //Problem 18.
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        Customer[] customers = context.Customers
            .Where(c => c.Sales.Any())
            .Include(c => c.Sales)
            .ThenInclude(s => s.Car)
            .ThenInclude(c => c.PartsCars)
            .ThenInclude(pc => pc.Part)
            .ToArray();

        var customersDTOs = new HashSet<ExportCustomerSaleDTO>();

        foreach (Customer customer in customers)
        {
            customersDTOs.Add(new ExportCustomerSaleDTO
            {
                FullName = customer.Name,
                BoughtCars = customer.Sales.Count,
                SpentMoney = Math.Round(customer.Sales
                    .Sum(s => s.Car.PartsCars
                        .Sum(pc => pc.Part.Price)) * (1 - (customer.IsYoungDriver ? 0.05M : 0)), 2, MidpointRounding.ToZero)
            });
        }

        return XmlHelper.Serialize(customersDTOs
            .OrderByDescending(c => c.SpentMoney)
            .ToArray(), "customers");
    }

    //Problem 19.
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        ExportSaleWithDiscountDTO[] sales = context.Sales
            .Select(s => new ExportSaleWithDiscountDTO
            {
                Car = new ExportSaleCarDTO
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                Discount = s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                PriceWithDiscount = Math.Round((double) (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100)), 4)
            })
            .ToArray();

        return XmlHelper.Serialize(sales, "sales");
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg 
            => cfg.AddProfile(new CarDealerProfile())));
}