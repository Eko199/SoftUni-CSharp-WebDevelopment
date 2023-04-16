namespace Blog.Core.Services;

using Microsoft.EntityFrameworkCore;

using Contracts;
using Data;
using Data.Models;
using Models.Article;
using Models.Category;

public class ArticleService : IArticleService
{
    private readonly BlogDbContext context;

    public ArticleService(BlogDbContext context)
    {
        this.context = context;
    }

    public async Task<ArticleViewModel?> GetByIdAsync(int id)
        => await context.Articles
            .Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedOn = a.CreatedOn,
                Author = a.Author.UserName,
                Category = a.Category.Name
            })
            .SingleOrDefaultAsync(a => a.Id == id);

    public async Task<ArticleEditViewModel?> GetByIdForEditAsync(int id)
        => await context.Articles
            .Select(a => new ArticleEditViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CategoryId = a.Category.Id,
                Categories = context.Categories
                    .Select(c => new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToArray()
            })
            .SingleOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<ArticleViewModel>> GetAllAsync()
        => await context.Articles
            .Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                CreatedOn = a.CreatedOn,
                Author = a.Author.UserName,
                Category = a.Category.Name
            })
            .ToArrayAsync();

    public async Task AddAsync(ArticleAddViewModel model)
    {
        await context.Articles.AddAsync(new Article
        {
            Title = model.Title,
            Content = model.Content,
            CreatedOn = model.CreatedOn,
            AuthorId = model.AuthorId,
            CategoryId = model.CategoryId
        });

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ArticleEditViewModel model)
    {
        Article article = await context.Articles.SingleAsync(a => a.Id == model.Id);

        article.Title = model.Title;
        article.Content = model.Content;
        article.CategoryId = model.CategoryId;

        await context.SaveChangesAsync();
    }
}