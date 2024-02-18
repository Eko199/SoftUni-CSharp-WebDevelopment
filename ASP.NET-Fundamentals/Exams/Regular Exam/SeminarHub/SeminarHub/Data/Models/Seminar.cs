namespace SeminarHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DataConstants;

public class Seminar
{
    [Key]
    [Comment("Unique seminar identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(SeminarTopicMaxLength)]
    [Comment("Seminar topic")]
    public string Topic { get; set; } = string.Empty;

    [Required]
    [MaxLength(SeminarLecturerMaxLength)]
    [Comment("Seminar lecturer name")]
    public string Lecturer { get; set; } = string.Empty;

    [Required]
    [MaxLength(SeminarDetailsMaxLength)]
    [Comment("Seminar details")]
    public string Details { get; set; } = string.Empty;

    [Required]
    [Comment("Identifier of seminar organizer")]
    public string OrganizerId { get; set; } = string.Empty;

    [ForeignKey(nameof(OrganizerId))] 
    public IdentityUser Organizer { get; set; } = null!;

    [Required]
    [Comment("Seminar date and time")]
    public DateTime DateAndTime { get; set; }

    [Comment("Seminar duration in minutes")]
    public int? Duration { get; set; }

    [Required]
    [Comment("Identifier of seminar category")]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))] 
    public Category Category { get; set; } = null!;

    public ICollection<SeminarParticipant> SeminarParticipants { get; set; } = new HashSet<SeminarParticipant>();
}