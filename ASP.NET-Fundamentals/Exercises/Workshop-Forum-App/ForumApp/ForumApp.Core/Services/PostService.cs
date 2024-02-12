namespace ForumApp.Core.Services;

using Contracts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.Extensions.Logging;
using Models;

public class PostService : IPostService
{
    private readonly ILogger<PostService> logger;
    private readonly ForumAppDbContext context;

    public PostService(ILogger<PostService> logger, ForumAppDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task<PostModel?> FindByIdAsync(int id)
    {
        Post? post = await context.FindAsync<Post>(id);

        return post is null ? null : new PostModel
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content
        };
    }

    public async Task<IEnumerable<PostModel>> GetAllAsync() 
        => await context.Posts.Select(p => new PostModel
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content
        }).ToListAsync();

    public async Task AddAsync(PostModel post)
    {
        try
        {
            await context.AddAsync(new Post
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            });

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "In post service add");
            throw new ApplicationException("Something went wrong. Please try again.");
        }
    }

    public async Task EditAsync(PostModel post)
    {
        Post entity = await context.FindAsync<Post>(post.Id)
            ?? throw new ApplicationException("Something went wrong. Please try again.");

        entity.Title = post.Title;
        entity.Content = post.Content;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Post entity = await context.FindAsync<Post>(id)
                      ?? throw new ApplicationException("Something went wrong. Please try again.");

        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}