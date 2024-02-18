namespace SeminarHub.Services;

using Microsoft.EntityFrameworkCore;
using Contracts;
using Data;
using Models.Category;

public class CategoryService : ICategoryService
{
    private readonly SeminarHubDbContext context;

    public CategoryService(SeminarHubDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        => await context.Categories.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name
        }).ToListAsync();
}