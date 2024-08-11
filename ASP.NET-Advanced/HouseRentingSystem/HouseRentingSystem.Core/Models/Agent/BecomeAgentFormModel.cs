namespace HouseRentingSystem.Core.Models.Agent;

using System.ComponentModel.DataAnnotations;
using static Infrastructure.DataConstants.Agent;

public class BecomeAgentFormModel
{
    [Required]
    [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
    [Display(Name = "Phone Number")]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
}