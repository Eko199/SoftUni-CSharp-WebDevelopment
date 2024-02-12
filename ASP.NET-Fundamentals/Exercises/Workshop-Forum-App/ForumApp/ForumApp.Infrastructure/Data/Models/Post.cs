namespace ForumApp.Infrastructure.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Constants.ValidationConstants;

public class Post
{
    [Key]
    [Comment("Unique post identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(PostTitleMaxLength)]
    [Comment("Title of the post")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(PostContentMaxLength)]
    [Comment("Content of the post")]
    public string Content { get; set; } = string.Empty;
}