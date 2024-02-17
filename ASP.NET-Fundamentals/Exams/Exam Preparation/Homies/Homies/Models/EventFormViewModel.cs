namespace Homies.Models;

using System.ComponentModel.DataAnnotations;
using static Data.DataConstants;

/// <summary>
/// View model for event forms and validation
/// </summary>
public class EventFormViewModel
{
    /// <summary>
    /// Event name
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Event description
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Date and time of event start
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public DateTime Start { get; set; }

    /// <summary>
    /// Date and time of event end
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public DateTime End { get; set; }

    /// <summary>
    /// Identifier of task type
    /// </summary>
    [Required(ErrorMessage = RequiredErrorMessage)]
    public int TypeId { get; set; }
    
    /// <summary>
    /// List of all available types for selection in form
    /// </summary>
    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}