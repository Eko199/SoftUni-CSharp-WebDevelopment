namespace ProductShop;

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
        using var context = new ProductShopContext();

        string json = GetUsersWithProducts(context);

        Console.WriteLine(json);
        File.WriteAllText("../../../Results/users-and-products.json", json);
    }

    //Problem 01.
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        var userDTOs = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);
        var users = CreateMapper().Map<User[]>(userDTOs);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Length}";
    }

    //Problem 02.
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        var productDTOs = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);
        var products = CreateMapper().Map<Product[]>(productDTOs);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    //Problem 03.
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        var categoryDTOs = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);
        var categories = CreateMapper().Map<Category[]>(categoryDTOs!.Where(c => c.Name != null));

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Length}";
    }

    //Problem 04.
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        var categoryProductDTOs = JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);
        var categoryProducts = CreateMapper().Map<CategoryProduct[]>(categoryProductDTOs);

        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Length}";
    }

    //Problem 05.
    public static string GetProductsInRange(ProductShopContext context) 
        => JsonConvert.SerializeObject(context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                p.Name,
                p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
            })
            .ToArray(), Formatting.Indented, CreateJsonSerializerSettings());

    //Problem 06.
    public static string GetSoldProducts(ProductShopContext context)
        => JsonConvert.SerializeObject(context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId.HasValue)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer!.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
            })
            .ToArray(), Formatting.Indented, CreateJsonSerializerSettings());

    //Problem 07.
    public static string GetCategoriesByProductsCount(ProductShopContext context)
        => JsonConvert.SerializeObject(context.Categories
            .OrderByDescending(c => c.CategoriesProducts.Count)
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("F2"),
                TotalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("F2")
            })
            .ToArray(), Formatting.Indented, CreateJsonSerializerSettings());

    //Problem 08.
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                    Products = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                }
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .ToArray();

        return JsonConvert.SerializeObject(new
        {
            UsersCount = users.Length,
            users
        }, Formatting.Indented, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg 
            => cfg.AddProfile(new ProductShopProfile())));

    private static JsonSerializerSettings CreateJsonSerializerSettings()
        => new() 
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
}