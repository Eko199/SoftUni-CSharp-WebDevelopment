namespace TaskBoardApp.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static DataConstants;

[Comment("Board to hold tasks")]
public class Board
{
    [Key]
    [Comment("Unique board identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(BoardMaxNameLength)]
    [Comment("Board name")]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();
}