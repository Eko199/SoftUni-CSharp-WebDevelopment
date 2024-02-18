namespace SeminarHub.Models.Seminar;

/// <summary>
/// View model for seminar delete page
/// </summary>
public class SeminarDeleteViewModel
{
    /// <summary>
    /// Unique seminar identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Seminar topic
    /// </summary>
    public string Topic { get; set; } = string.Empty;

    /// <summary>
    /// Seminar date and time
    /// </summary>
    public DateTime DateAndTime { get; set; }

    /// <summary>
    /// Identifier of seminar organizer, used for authorization
    /// </summary>
    public string OrganizerId { get; set; } = string.Empty;
}