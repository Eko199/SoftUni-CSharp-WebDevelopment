namespace SeminarHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class SeminarParticipant
{
    [Required]
    [Comment("Seminar identifier, part of composite primary key")]
    public int SeminarId { get; set; }

    [ForeignKey(nameof(SeminarId))] 
    public Seminar Seminar { get; set; } = null!;

    [Required]
    [Comment("Participant identifier, part of composite primary key")]
    public string ParticipantId { get; set; } = string.Empty;

    [ForeignKey(nameof(ParticipantId))] 
    public IdentityUser Participant { get; set; } = null!;
}