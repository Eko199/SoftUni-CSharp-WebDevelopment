namespace HouseRentingSystem.Infrastructure.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static DataConstants.ApplicationUser;

public class ApplicationUser : IdentityUser
{
    [Required]
    [MaxLength(FirstNameMaxLength)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(LastNameMaxLength)]
    public string LastName { get; set; } = string.Empty;
}
