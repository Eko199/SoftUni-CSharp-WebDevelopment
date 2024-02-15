namespace TaskBoardApp.Services.Contracts;

using TaskBoardApp.Models.Task;

public interface ITaskService
{
    Task AddAsync(TaskFormModel task, string userId);

    Task<TaskDetailsViewModel?> GetDetailsByIdAsync(int id);

    Task<TaskEditFormModel?> GetEditByIdAsync(int id);

    Task EditAsync(TaskFormModel task);

    Task DeleteAsync(int id);
}