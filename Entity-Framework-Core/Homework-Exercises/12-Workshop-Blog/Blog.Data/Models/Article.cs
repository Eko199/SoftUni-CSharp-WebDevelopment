namespace Blog.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Article
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(50)] 
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(1500)]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    [ForeignKey(nameof(Author))]
    public string AuthorId { get; set; } = null!;
    public virtual ApplicationUser Author { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}