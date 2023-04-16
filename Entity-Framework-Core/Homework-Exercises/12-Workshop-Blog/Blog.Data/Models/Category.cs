namespace Blog.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        Articles = new HashSet<Article>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; }
}