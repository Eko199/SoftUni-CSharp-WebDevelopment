namespace Eventmi.Core.Services.Contracts;

using Models;

public interface IEventService
{
    Task<IEnumerable<EventFormModel>> GetAllAsync();

    Task AddAsync(EventFormModel model);

    Task UpdateAsync(EventFormModel model);

    Task DeleteAsync(int id);

    Task<EventFormModel> GetByIdAsync(int id);
}