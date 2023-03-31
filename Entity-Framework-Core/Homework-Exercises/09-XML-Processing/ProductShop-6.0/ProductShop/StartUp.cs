namespace ProductShop;

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
        using var context = new ProductShopContext();
        string xml = GetUsersWithProducts(context);

        Console.WriteLine(xml);
        File.WriteAllText("../../../Results/users-and-products.xml", xml);
    }

    //Problem 01.
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        ImportUserDTO[] userDTOs = XmlHelper.Deserialize<ImportUserDTO[]>(inputXml, "Users");
        User[] users = CreateMapper().Map<User[]>(userDTOs);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Length}";
    }

    //Problem 02.
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        ImportProductDTO[] productDTOs = XmlHelper.Deserialize<ImportProductDTO[]>(inputXml, "Products");
        Product[] products = CreateMapper().Map<Product[]>(productDTOs);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    //Problem 03.
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        ImportCategoryDTO[] categoryDTOs = XmlHelper.Deserialize<ImportCategoryDTO[]>(inputXml, "Categories");
        Category[] categories = CreateMapper().Map<Category[]>(categoryDTOs.Where(c => c.Name != null));

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Length}";
    }

    //Problem 04.
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        ImportCategoryProductDTO[] categoryProductDTOs = XmlHelper.Deserialize<ImportCategoryProductDTO[]>(inputXml, "CategoryProducts");
        CategoryProduct[] categoryProducts = CreateMapper()
            .Map<CategoryProduct[]>(categoryProductDTOs
                .Where(cp => 
                    context.Categories.Any(c => c.Id == cp.CategoryId) 
                    && context.Products.Any(p => p.Id == cp.ProductId)));

        context.CategoryProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }

    //Problem 05.
    public static string GetProductsInRange(ProductShopContext context)
    {
        ExportProductInRangeDTO[] products = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Take(10)
            .ProjectTo<ExportProductInRangeDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(products, "Products");
    }

    //Problem 06.
    public static string GetSoldProducts(ProductShopContext context)
    {
        ExportUserSoldProductsDTO[] users = context.Users
            .Where(u => u.ProductsSold.Any())
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .ProjectTo<ExportUserSoldProductsDTO>(CreateMapper().ConfigurationProvider)
            .ToArray();

        return XmlHelper.Serialize(users, "Users");
    }

    //Problem 07.
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        ExportCategoryByProductCountDTO[] categories = context.Categories
            .Select(c => new ExportCategoryByProductCountDTO
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count(),
                AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                TotalRevenue = c.CategoryProducts.Sum(c => c.Product.Price)
            })
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.TotalRevenue)
            .ToArray();

        return XmlHelper.Serialize(categories, "Categories");
    }

    //Problem 08.
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        ExportUserAndProductsDTO[] usersAndProductsDTOs = context.Users
            .Where(u => u.ProductsSold.Any())
            .Include(u => u.ProductsSold)
            .OrderByDescending(u => u.ProductsSold.Count)
            .AsEnumerable()
            .Select(u => new ExportUserAndProductsDTO
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new ExportSoldProductsDTO
                {
                    Count = u.ProductsSold.Count,
                    Products = u.ProductsSold
                        .Select(p => new ExportProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                }
            })
            .ToArray();

        var users = new ExportUsersDTO
        {
            Count = usersAndProductsDTOs.Length,
            Users = usersAndProductsDTOs
                .Take(10)
                .ToArray()
        };

        return XmlHelper.SerializeRootIncluded(users);
    }

    public static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg 
            => cfg.AddProfile(new ProductShopProfile())));
}