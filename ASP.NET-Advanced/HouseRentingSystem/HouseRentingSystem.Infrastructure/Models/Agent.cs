namespace HouseRentingSystem.Infrastructure.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static DataConstants.Agent;

[Index(nameof(PhoneNumber), IsUnique = true)]
public class Agent
{
    public int Id { get; init; }

    [Required]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;
}