namespace HouseRentingSystem.Infrastructure.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static DataConstants.Agent;

public class Agent
{
    public int Id { get; init; }

    [Required]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;
}