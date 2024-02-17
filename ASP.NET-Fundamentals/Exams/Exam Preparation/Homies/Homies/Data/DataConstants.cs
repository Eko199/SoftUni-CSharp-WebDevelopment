namespace Homies.Data;

/// <summary>
/// Constants for model validation
/// </summary>
public class DataConstants
{
    //Type constants:--------------------------------

    /// <summary>
    /// Type name must be at least 5 characters long.
    /// </summary>
    public const int TypeNameMinLength = 5;

    /// <summary>
    /// Type name must be at most 15 characters long.
    /// </summary>
    public const int TypeNameMaxLength = 15;

    //Event constants:--------------------------------

    /// <summary>
    /// Event name must be at least 5 characters long.
    /// </summary>
    public const int EventNameMinLength = 5;

    /// <summary>
    /// Event name must be at most 20 characters long.
    /// </summary>
    public const int EventNameMaxLength = 20;

    /// <summary>
    /// Event name must be at least 15 characters long.
    /// </summary>
    public const int EventDescriptionMinLength = 15;

    /// <summary>
    /// Event name must be at most 150 characters long.
    /// </summary>
    public const int EventDescriptionMaxLength = 150;

    /// <summary>
    /// Format for displaying event dates
    /// </summary>
    public const string DateFormat = "yyyy-MM-dd H:mm";

    //Event constants:--------------------------------

    /// <summary>
    /// Error message for missing required fields
    /// </summary>
    public const string RequiredErrorMessage = "The field {0} is required!";

    /// <summary>
    /// Error message for invalid string field length
    /// </summary>
    public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long!";
}