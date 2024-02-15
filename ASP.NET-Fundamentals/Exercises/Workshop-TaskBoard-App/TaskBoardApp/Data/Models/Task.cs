namespace TaskBoardApp.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DataConstants;

[Comment("Tasks table")]
public class Task
{
    [Key]
    [Comment("Unique task identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(TaskMaxTitleLength)]
    [Comment("Task title")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(TaskMaxDescriptionLength)]
    [Comment("Task description")]
    public string Description { get; set; } = string.Empty;

    [Comment("Server date and time of task creation")]
    public DateTime? CreatedOn { get; set; }

    [Comment("Unique identifier of the task's board")]
    public int? BoardId { get; set; }

    [ForeignKey(nameof(BoardId))]
    public Board? Board { get; set; }

    [Required]
    [Comment("Unique identifier of the task's owner")]
    public string OwnerId { get; set; } = string.Empty;

    [Required]
    [ForeignKey(nameof(OwnerId))]
    public IdentityUser Owner { get; set; } = null!;
}