namespace Homies.Services.Contracts;

using Models;

public interface ITypeService
{
    Task<IEnumerable<TypeViewModel>> GetAllAsync();
}