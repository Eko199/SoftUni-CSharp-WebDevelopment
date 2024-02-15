namespace TaskBoardApp.Models.Board;

using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Models.Task;
using static Data.DataConstants;

/// <summary>
/// View model for displaying the board entity
/// </summary>
public class BoardViewModel
{
    /// <summary>
    /// Unique board identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Board name
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(BoardMaxNameLength, MinimumLength = BoardMinNameLength, ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Tasks in this board
    /// </summary>
    public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
}