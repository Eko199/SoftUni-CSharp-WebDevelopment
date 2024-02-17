namespace Homies.Models;

/// <summary>
/// View model for visualizing short event info
/// </summary>
public class EventViewModel
{
    /// <summary>
    /// Unique event identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Event name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Username of event creator
    /// </summary>
    public string Organiser { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of event start
    /// </summary>
    public string Start { get; set; } = string.Empty;
    
    /// <summary>
    /// Type name of event
    /// </summary>
    public string Type { get; set; } = string.Empty;
}