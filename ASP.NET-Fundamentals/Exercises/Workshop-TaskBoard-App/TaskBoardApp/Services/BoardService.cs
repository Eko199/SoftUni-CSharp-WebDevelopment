namespace TaskBoardApp.Services;

using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Board;
using Models.Task;

public class BoardService : IBoardService
{
    private readonly TaskBoardAppDbContext context;

    public BoardService(TaskBoardAppDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<BoardViewModel>> GetAllAsync()
        => await context.Boards
            .Select(b => new BoardViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Tasks = b.Tasks.Select(t => new TaskViewModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName
                })
            })
            .ToListAsync();

    public async Task<IEnumerable<BoardSelectModel>> GetAllForSelectAsync() 
        => await context.Boards
        .Select(b => new BoardSelectModel
        {
            Id = b.Id,
            Name = b.Name
        })
        .ToListAsync();

    public async Task<HomeViewModel> GetHomeViewModelAsync(string? userId)
    {
        var result = new HomeViewModel
        {
            AllTasksCount = await context.Tasks.CountAsync(),
            UserTasksCount = -1
        };

        await context.Boards
            .Include(b => b.Tasks)
            .ForEachAsync(b =>
            {
                result.BoardsWithTasksCount.Add(new KeyValuePair<string, int>(b.Name, b.Tasks.Count()));
            });

        if (userId != null)
        {
            result.UserTasksCount = await context.Tasks.CountAsync(t => t.OwnerId == userId);
        }

        return result;
    }
}