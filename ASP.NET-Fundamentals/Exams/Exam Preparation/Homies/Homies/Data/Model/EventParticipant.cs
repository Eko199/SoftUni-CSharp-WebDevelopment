namespace Homies.Data.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class EventParticipant
{
    [Required]
    [Comment("Identifier of event helper")]
    public string HelperId { get; set; } = string.Empty;

    [ForeignKey(nameof(HelperId))]
    public IdentityUser Helper { get; set; } = null!;

    [Required]
    [Comment("Identifier of user event")]
    public int EventId { get; set; }

    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; } = null!;
}