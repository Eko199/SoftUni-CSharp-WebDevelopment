namespace SeminarHub.Data;

/// <summary>
/// Constants for data validation
/// </summary>
public static class DataConstants
{
    //Category constants:-------------------------------------

    /// <summary>
    /// Category name must be at least 3 characters long.
    /// </summary>
    public const int CategoryNameMinLength = 3;

    /// <summary>
    /// Category name must be at most 50 characters long.
    /// </summary>
    public const int CategoryNameMaxLength = 50;

    //Seminar constants:-------------------------------------

    /// <summary>
    /// Seminar topic must be at least 3 characters long.
    /// </summary>
    public const int SeminarTopicMinLength = 3;

    /// <summary>
    /// Seminar topic must be at most 100 characters long.
    /// </summary>
    public const int SeminarTopicMaxLength = 100;

    /// <summary>
    /// Seminar lecturer name must be at least 5 characters long.
    /// </summary>
    public const int SeminarLecturerMinLength = 5;

    /// <summary>
    /// Seminar lecturer name must be at most 60 characters long.
    /// </summary>
    public const int SeminarLecturerMaxLength = 60;

    /// <summary>
    /// Seminar details must be at least 10 characters long.
    /// </summary>
    public const int SeminarDetailsMinLength = 10;

    /// <summary>
    /// Seminar details must be at most 500 characters long.
    /// </summary>
    public const int SeminarDetailsMaxLength = 500;

    /// <summary>
    /// Seminar duration must be at least 30 minutes long.
    /// </summary>
    public const int SeminarMinDuration = 30;


    /// <summary>
    /// Seminar duration must be at most 180 minutes long.
    /// </summary>
    public const int SeminarMaxDuration = 180;

    /// <summary>
    /// Default date visualization format
    /// </summary>
    public const string DateFormat = "dd/MM/yyyy HH:mm";

    //Error messages:-------------------------------------

    /// <summary>
    /// Error message for required fields
    /// </summary>
    public const string RequiredErrorMessage = "The field {0} is required!";

    /// <summary>
    /// Error message for invalid length of string fields
    /// </summary>
    public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long!";

    /// <summary>
    /// Error message for invalid value of number fields
    /// </summary>
    public const string RangeErrorMessage = "The field {0} must be between {1} and {2}!";
}