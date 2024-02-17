namespace Homies.Models;

/// <summary>
/// View model for editing an event
/// </summary>
public class EventEditViewModel : EventFormViewModel
{
    /// <summary>
    /// Identifier of event creator, used for authorizing the editor
    /// </summary>
    public string OrganiserId { get; set; } = string.Empty;
}