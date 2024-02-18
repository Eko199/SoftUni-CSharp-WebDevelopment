namespace SeminarHub.Services.Contracts;

using Models.Seminar;

public interface ISeminarService
{
    Task<IEnumerable<SeminarViewModel>> GetAllAsync();

    Task<IEnumerable<SeminarViewModel>> GetAllJoinedAsync(string userId);

    Task AddAsync(SeminarFormModel seminar);

    Task EditAsync(int id, SeminarFormModel seminar);

    Task DeleteAsync(int id);

    Task<SeminarDetailsViewModel?> GetDetailsByIdAsync(int id);

    Task<SeminarFormModel?> GetFormModelByIdAsync(int id);

    Task<SeminarDeleteViewModel?> GetDeleteModelByIdAsync(int id);

    Task<bool> JoinAsync(int seminarId, string userId);

    Task<bool> LeaveAsync(int seminarId, string userId);
}