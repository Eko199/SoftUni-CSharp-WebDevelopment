namespace PetStore.Services.Data;

using Microsoft.EntityFrameworkCore;

using Models;
using PetStore.Data.Common.Repos;
using PetStore.Data.Models;

public class CategoryService : ICategoryService
{
    private readonly IDeletableEntityRepository<Category> _repository;

    public CategoryService(IDeletableEntityRepository<Category> repository)
    {
        this._repository = repository;
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync() 
        => await _repository.AllAsNoTracking()
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArrayAsync();

    public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
    {
        Category category = await _repository
            .AllAsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id) ?? throw new ArgumentException("Invalid id!");

        return new CategoryViewModel
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public async Task UpdateCategoryAsync(CategoryViewModel category)
    {
        Category categoryToUpdate = await _repository
            .All()
            .SingleAsync(c => c.Id == category.Id);

        categoryToUpdate.Name = category.Name;

        _repository.Update(categoryToUpdate);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        Category category = await _repository
            .All()
            .SingleAsync(c => c.Id == id);

        _repository.Delete(category);
        await _repository.SaveChangesAsync();
    }
}