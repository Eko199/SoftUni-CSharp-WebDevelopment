namespace ForumApp.Infrastructure.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    private readonly Post[] posts =
    {
        new()
        {
            Id = 1,
            Title = "My first post",
            Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!"
        },
        new()
        {
            Id = 2,
            Title = "My second post",
            Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!"
        },
        new()
        {
            Id = 3,
            Title = "My third post",
            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tuned!"
        }
    };

    public void Configure(EntityTypeBuilder<Post> builder) => builder.HasData(posts);
}