namespace Homies.Data.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DataConstants;

public class Event
{
    [Key]
    [Comment("Unique event identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(EventNameMaxLength)]
    [Comment("Event name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(EventDescriptionMaxLength)]
    [Comment("Event description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Comment("Identifier of event creator")]
    public string OrganiserId { get; set; } = string.Empty;

    [ForeignKey(nameof(OrganiserId))] 
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    [Comment("Date and time of event creation")]
    public DateTime CreatedOn { get; set; }

    [Required]
    [Comment("Date and time of event start")]
    public DateTime Start { get; set; }

    [Required]
    [Comment("Date and time of event end")]
    public DateTime End { get; set; }

    [Required]
    [Comment("Identifier of task type")]
    public int TypeId { get; set; }

    [ForeignKey(nameof(TypeId))]
    public Type Type { get; set; } = null!;

    public ICollection<EventParticipant> EventParticipants { get; set; } = new HashSet<EventParticipant>();
}