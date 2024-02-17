namespace Homies.Services.Contracts;

using Models;

public interface IEventService
{
    Task<IEnumerable<EventViewModel>> GetAllAsync();

    Task<IEnumerable<EventViewModel>> GetAllJoinedAsync(string userId);

    Task<bool> JoinAsync(string userId, int eventId);

    Task<bool> LeaveAsync(string userId, int eventId);

    Task AddAsync(EventFormViewModel model, string userId);

    Task EditAsync(int id, EventFormViewModel model);

    Task<EventDetailsViewModel?> GetDetailsByIdAsync(int id);

    Task<EventEditViewModel?> GetFormModelByIdAsync(int id);
}