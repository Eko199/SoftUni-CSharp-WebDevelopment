namespace TaskBoardApp.Services.Contracts;

using Models;
using Models.Board;

public interface IBoardService
{
    Task<IEnumerable<BoardViewModel>> GetAllAsync();

    Task<IEnumerable<BoardSelectModel>> GetAllForSelectAsync();

    Task<HomeViewModel> GetHomeViewModelAsync(string? userId);
}