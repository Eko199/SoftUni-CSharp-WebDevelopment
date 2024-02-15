namespace TaskBoardApp.Models.Task;

/// <summary>
/// View model for task with more details
/// </summary>
public class TaskDetailsViewModel : TaskViewModel
{
    /// <summary>
    /// Date and time of task creation as a string
    /// </summary>
    public string CreatedOn { get; set; } = string.Empty;

    /// <summary>
    /// Name of task's board
    /// </summary>
    public string Board { get; set; } = string.Empty;
}