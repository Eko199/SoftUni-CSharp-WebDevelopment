namespace TaskBoardApp.Data;

/// <summary>
/// Validation constants for entities and models
/// </summary>
public static class DataConstants
{
    //Task constants:--------------------------------------

    /// <summary>
    /// The task title must be at least 5 characters long.
    /// </summary>
    public const int TaskMinTitleLength = 5;

    /// <summary>
    /// The task title must be at most 70 characters long.
    /// </summary>
    public const int TaskMaxTitleLength = 70;

    /// <summary>
    /// The task description must be at least 10 characters long.
    /// </summary>
    public const int TaskMinDescriptionLength = 10;

    /// <summary>
    /// The task description must be at most 1000 characters long.
    /// </summary>
    public const int TaskMaxDescriptionLength = 1000;

    //Board constants:-------------------------------------

    /// <summary>
    /// The board name must be at least 3 characters long.
    /// </summary>
    public const int BoardMinNameLength = 3;

    /// <summary>
    /// The board name must be at most 30 characters long.
    /// </summary>
    public const int BoardMaxNameLength = 30;

    //Error messages:--------------------------------------

    /// <summary>
    /// Error message to be displayed when a required field is missing
    /// </summary>
    public const string RequiredErrorMessage = "The field {0} is required!";

    /// <summary>
    /// Error message to be displayed when a string field doesn't meet length criteria
    /// </summary>
    public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long!";
}