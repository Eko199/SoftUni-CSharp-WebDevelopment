namespace HouseRentingSystem.Core.Models.ApplicationUser;

public class UserServiceModel
{
    public string Email { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public bool IsAgent { get; set; }
}