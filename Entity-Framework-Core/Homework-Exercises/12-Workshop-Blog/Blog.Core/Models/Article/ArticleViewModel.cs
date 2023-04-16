namespace Blog.Core.Models.Article;

public class ArticleViewModel
{
    public int Id { get; set; }
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;
    
    public DateTime CreatedOn { get; set; }

    public string Author { get; set; } = null!;

    public string Category { get; set; } = null!;
}