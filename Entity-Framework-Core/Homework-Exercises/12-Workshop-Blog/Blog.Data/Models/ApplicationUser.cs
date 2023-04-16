namespace Blog.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(nameof(UserName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class ApplicationUser
{
    public ApplicationUser()
    {
        Id = Guid.NewGuid().ToString();
        Articles = new HashSet<Article>();
    }

    [Key]
    public string Id { get; set; }

    [Required]
    [MaxLength(20)] 
    public string UserName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string PasswordSalt { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; }
}