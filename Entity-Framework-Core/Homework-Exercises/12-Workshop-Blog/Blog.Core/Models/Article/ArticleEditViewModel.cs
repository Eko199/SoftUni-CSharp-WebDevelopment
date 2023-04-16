namespace Blog.Core.Models.Article;

using System.ComponentModel.DataAnnotations;

using Category;

public class ArticleEditViewModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 10)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(1500, MinimumLength = 50)]
    public string Content { get; set; } = null!;

    [Required]
    public int CategoryId { get; set; }

    public ICollection<CategoryViewModel> Categories { get; set; } = null!;
}