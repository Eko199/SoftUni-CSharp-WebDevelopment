namespace Blog.Core.Services;

using Microsoft.EntityFrameworkCore;

using Contracts;
using Data;
using Models.Category;

public class CategoryService : ICategoryService
{
    private readonly BlogDbContext context;

    public CategoryService(BlogDbContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<CategoryViewModel>> GetAllAsync()
        => await context.Categories
            .Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToArrayAsync();
}