namespace Homies.Models;

/// <summary>
/// View model for type selection in forms
/// </summary>
public class TypeViewModel
{
    /// <summary>
    /// Unique type identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}