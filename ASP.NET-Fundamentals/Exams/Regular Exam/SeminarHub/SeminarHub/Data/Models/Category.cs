namespace SeminarHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Category
{
    [Key]
    [Comment("Unique category identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(DataConstants.CategoryNameMaxLength)]
    [Comment("Category name")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
}