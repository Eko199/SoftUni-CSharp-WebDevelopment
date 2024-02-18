namespace SeminarHub.Models.Seminar;

using System.ComponentModel.DataAnnotations;
using Category;
using static Data.DataConstants;

/// <summary>
/// View model for seminar in forms and used for validations (add, edit)
/// </summary>
public class SeminarFormModel
{
    /// <summary>
    /// Seminar topic
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(SeminarTopicMaxLength, MinimumLength = SeminarTopicMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Topic { get; set; } = string.Empty;

    /// <summary>
    /// Seminar lecturer name
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(SeminarLecturerMaxLength, MinimumLength = SeminarLecturerMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Lecturer { get; set; } = string.Empty;

    /// <summary>
    /// Seminar details
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(SeminarDetailsMaxLength, MinimumLength = SeminarDetailsMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Details { get; set; } = string.Empty;

    /// <summary>
    /// Seminar date and time
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public DateTime DateAndTime { get; set; }

    /// <summary>
    /// Seminar duration in minutes
    /// </summary>
    [Range(SeminarMinDuration, SeminarMaxDuration, ErrorMessage = RangeErrorMessage)]
    public int? Duration { get; set; }

    /// <summary>
    /// Identifier of seminar category
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Identifier of seminar organizer, used for authorization
    /// </summary>
    public string OrganiserId { get; set; } = string.Empty;

    /// <summary>
    /// Collection of all categories for visualization in form
    /// </summary>
    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}