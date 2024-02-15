namespace TaskBoardApp.Models.Task;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// View model for task editing (need owner identifier)
/// </summary>
public class TaskEditFormModel : TaskFormModel
{
    /// <summary>
    /// Identifier of task's owner
    /// </summary>
    [Required(ErrorMessage = Data.DataConstants.RequiredErrorMessage)]
    public string OwnerId { get; set; } = string.Empty;
}