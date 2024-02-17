namespace Homies.Models;

/// <summary>
/// View model with extra details for event
/// </summary>
public class EventDetailsViewModel : EventViewModel
{
    /// <summary>
    /// Event description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of event end
    /// </summary>
    public string End { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of event creation
    /// </summary>
    public string CreatedOn { get; set; } = string.Empty;
}