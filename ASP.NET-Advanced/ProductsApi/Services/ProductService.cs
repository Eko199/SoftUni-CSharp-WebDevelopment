namespace ProductsApi.Services;

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductService(ProductDbContext data) : IProductService
{
    public async Task<IList<Product>> GetAllAsync() => await data.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id) => await data.Products.FindAsync(id);

    public async Task<Product> CreateAsync(string name, string description)
    {
        var product = new Product
        {
            Name = name,
            Description = description
        };

        await data.Products.AddAsync(product);
        await data.SaveChangesAsync();

        return product;
    }

    public async Task EditAsync(int id, Product product)
    {
        Product entity = await GetByIdOrThrowIfNull(id);

        entity.Name = product.Name;
        entity.Description = product.Description;

        await data.SaveChangesAsync();
    }

    public async Task EditPartiallyAsync(int id, Product product)
    {
        Product entity = await GetByIdOrThrowIfNull(id);

        entity.Name = string.IsNullOrEmpty(product.Name) ? entity.Name : product.Name;
        entity.Description = string.IsNullOrEmpty(product.Description) ? entity.Description : product.Description;

        await data.SaveChangesAsync();
    }

    public async Task<Product> DeleteAsync(int id)
    {
        Product product = await GetByIdOrThrowIfNull(id);

        data.Products.Remove(product);
        await data.SaveChangesAsync();

        return product;
    }

    private async Task<Product> GetByIdOrThrowIfNull(int id) => await GetByIdAsync(id) ?? throw new ArgumentException("Invalid id", nameof(id));
}