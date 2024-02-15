namespace TaskBoardApp.Models;

public class HomeViewModel
{
    public int AllTasksCount { get; init; }

    public IList<KeyValuePair<string, int>> BoardsWithTasksCount { get; init; } = new List<KeyValuePair<string, int>>();

    public int UserTasksCount { get; set; }
}