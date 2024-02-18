namespace SeminarHub.Models.Seminar;

/// <summary>
/// View model for seminar with more info
/// </summary>
public class SeminarDetailsViewModel : SeminarViewModel
{
    /// <summary>
    /// Seminar duration in minutes
    /// </summary>
    public int? Duration { get; set; }

    /// <summary>
    /// Seminar details
    /// </summary>
    public string Details { get; set; } = string.Empty;
}