namespace Blog.Core.Models.User;

using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(50, MinimumLength = 10)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string ConfirmPassword { get; set; } = null!;
}