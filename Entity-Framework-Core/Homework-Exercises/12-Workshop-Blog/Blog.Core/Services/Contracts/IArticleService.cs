namespace Blog.Core.Services.Contracts;

using Models.Article;

public interface IArticleService
{
    Task<ArticleViewModel?> GetByIdAsync(int id);

    Task<ArticleEditViewModel?> GetByIdForEditAsync(int id);

    Task<IEnumerable<ArticleViewModel>> GetAllAsync();

    Task AddAsync(ArticleAddViewModel model);

    Task UpdateAsync(ArticleEditViewModel model);
}