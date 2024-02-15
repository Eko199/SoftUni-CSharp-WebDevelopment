namespace TaskBoardApp.Models.Task;

using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Models.Board;
using static Data.DataConstants;

/// <summary>
/// View model for displaying tasks in forms (add, edit)
/// </summary>
public class TaskFormModel
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
    /// Identifier of task's board
    /// </summary>
    [Display(Name = "Board")]
    public int? BoardId { get; set; }

    /// <summary>
    /// List of all boards for choice
    /// </summary>
    public IEnumerable<BoardSelectModel> Boards { get; set; } = new List<BoardSelectModel>();
}