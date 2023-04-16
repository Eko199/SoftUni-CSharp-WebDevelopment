namespace Blog.Core.Services.Contracts;

using Models.Category;

public interface ICategoryService
{
    Task<ICollection<CategoryViewModel>> GetAllAsync();
}