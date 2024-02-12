namespace ForumApp.Infrastructure.Constants;

/// <summary>
/// Constants for validation of models and entities
/// </summary>
public static class ValidationConstants
{
    /// <summary>
    /// The post title should be at least 10 symbols long.
    /// </summary>
    public const int PostTitleMinLength = 10;

    /// <summary>
    /// The post title should be at most 50 symbols long.
    /// </summary>
    public const int PostTitleMaxLength = 50;

    /// <summary>
    /// The post content should be at least 30 symbols long.
    /// </summary>
    public const int PostContentMinLength = 30;

    /// <summary>
    /// The post content should be at most 1500 symbols long.
    /// </summary>
    public const int PostContentMaxLength = 1500;

    /// <summary>
    /// Displayed error message on validation of required fields
    /// </summary>
    public const string RequiredErrorMessage = "Field {0} is required!";

    /// <summary>
    /// Displayed error message on validation of string field length
    /// </summary>
    public const string StringLengthErrorMessage = "Field {0} must bee between {2} and {1} symbols long!";
}