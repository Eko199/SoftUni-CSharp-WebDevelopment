namespace ForumApp.Core.Models;

using System.ComponentModel.DataAnnotations;
using static Infrastructure.Constants.ValidationConstants;

/// <summary>
/// Data transfer object for the Post entity
/// </summary>
public class PostModel
{
    /// <summary>
    /// Unique post identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the post
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Content of the post
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Content { get; set; } = string.Empty;
}