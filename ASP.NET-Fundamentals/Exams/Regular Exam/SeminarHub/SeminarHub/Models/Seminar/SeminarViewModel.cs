namespace SeminarHub.Models.Seminar;

/// <summary>
/// View model for seminar short info
/// </summary>
public class SeminarViewModel
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
    /// Seminar lecturer name
    /// </summary>
    public string Lecturer { get; set; } = string.Empty;

    /// <summary>
    /// Seminar organizer username
    /// </summary>
    public string Organizer { get; set; } = null!;

    /// <summary>
    /// Seminar date and time
    /// </summary>
    public string DateAndTime { get; set; } = string.Empty;

    /// <summary>
    /// Seminar category name
    /// </summary>
    public string Category { get; set; } = string.Empty;
}