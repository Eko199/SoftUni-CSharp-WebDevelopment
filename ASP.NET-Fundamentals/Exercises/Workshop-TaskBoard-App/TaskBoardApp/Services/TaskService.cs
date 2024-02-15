namespace TaskBoardApp.Services;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using TaskBoardApp.Models.Task;

public class TaskService : ITaskService
{
    private readonly TaskBoardAppDbContext context;

    public TaskService(TaskBoardAppDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(TaskFormModel task, string userId)
    {
        await context.AddAsync(new Data.Models.Task
        {
            Title = task.Title,
            Description = task.Description,
            CreatedOn = DateTime.Now,
            BoardId = task.BoardId,
            OwnerId = userId
        });

        await context.SaveChangesAsync();
    }

    public async Task<TaskDetailsViewModel?> GetDetailsByIdAsync(int id)
        => await context.Tasks.Select(t => new TaskDetailsViewModel
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            CreatedOn = t.CreatedOn.HasValue
                ? t.CreatedOn.Value.ToString("dd/MM/yyyy HH:mm")
                : string.Empty,
            Board = t.Board == null
                ? string.Empty
                : t.Board.Name,
            Owner = t.Owner.UserName
        }).SingleOrDefaultAsync(t => t.Id == id);

    public async Task<TaskEditFormModel?> GetEditByIdAsync(int id)
    {
        var task = await context.Tasks.FindAsync(id);

        return task is null
            ? null
            : new TaskEditFormModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                OwnerId = task.OwnerId
            };
    }

    public async Task EditAsync(TaskFormModel task)
    {
        var entity = await context.Tasks.FindAsync(task.Id);

        if (entity is null)
        {
            throw new ApplicationException("Invalid task!");
        }

        entity.Title = task.Title;
        entity.Description = task.Description;
        entity.BoardId = task.BoardId;

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await context.Tasks.FindAsync(id);

        if (task is null)
        {
            throw new ApplicationException("Invalid task!");
        }

        context.Tasks.Remove(task);
        await context.SaveChangesAsync();
    }
}