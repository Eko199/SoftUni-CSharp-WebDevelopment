namespace SeminarHub.Services.Contracts;

using Models.Category;

public interface ICategoryService
{
    Task<IEnumerable<CategoryViewModel>> GetAllAsync();
}