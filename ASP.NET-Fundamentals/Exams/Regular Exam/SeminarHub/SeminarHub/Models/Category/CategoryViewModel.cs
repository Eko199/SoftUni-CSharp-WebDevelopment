namespace SeminarHub.Models.Category;

/// <summary>
/// View model for category visualization
/// </summary>
public class CategoryViewModel
{
    /// <summary>
    /// Unique category identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Category name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}