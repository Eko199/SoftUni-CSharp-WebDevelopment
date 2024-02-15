namespace TaskBoardApp.Models.Task;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants;

/// <summary>
/// View model for displaying tasks in board
/// </summary>
public class TaskViewModel
{
    /// <summary>
    /// Unique task identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Task title
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(TaskMaxTitleLength, MinimumLength = TaskMinTitleLength, ErrorMessage = StringLengthErrorMessage)]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(TaskMaxDescriptionLength, MinimumLength = TaskMinDescriptionLength, ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Username of task's owner
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public string Owner { get; set; } = string.Empty;
}