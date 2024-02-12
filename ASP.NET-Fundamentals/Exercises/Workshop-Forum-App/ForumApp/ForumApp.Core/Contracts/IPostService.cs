namespace ForumApp.Core.Contracts;

using Models;

public interface IPostService
{
    Task<PostModel?> FindByIdAsync(int id);

    Task<IEnumerable<PostModel>> GetAllAsync();

    Task AddAsync(PostModel post);

    Task EditAsync(PostModel post);

    Task DeleteAsync(int id);
}