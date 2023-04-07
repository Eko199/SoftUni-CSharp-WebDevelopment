namespace PetStore.Services.Data;

using Models;
using PetStore.Data.Models;

public interface ICategoryService
{
    Task AddCategoryAsync(Category category);

    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();

    Task<CategoryViewModel> GetCategoryByIdAsync(int id);

    Task UpdateCategoryAsync(CategoryViewModel category);

    Task DeleteCategoryAsync(int id);
}