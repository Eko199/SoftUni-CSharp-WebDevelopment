namespace ProductsApi.Services;

using Data;

public interface IProductService
{
    Task<IList<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> CreateAsync(string name, string description);

    Task EditAsync(int id, Product product);

    Task EditPartiallyAsync(int id, Product product);

    Task<Product> DeleteAsync(int id);
}