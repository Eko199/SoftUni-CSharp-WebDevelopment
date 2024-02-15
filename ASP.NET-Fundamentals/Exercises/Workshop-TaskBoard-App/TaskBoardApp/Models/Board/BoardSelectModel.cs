namespace TaskBoardApp.Models.Board;

/// <summary>
/// View model for selecting a board
/// </summary>
public class BoardSelectModel
{
    /// <summary>
    /// Unique board identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Board name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}