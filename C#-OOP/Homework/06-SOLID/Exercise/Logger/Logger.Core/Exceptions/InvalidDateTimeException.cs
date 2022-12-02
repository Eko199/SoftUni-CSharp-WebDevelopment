namespace Logger.Core.Exceptions;

public class InvalidDateTimeException : Exception
{
    private const string DefaultMessage = "Invalid Date and Time!";

    public InvalidDateTimeException() : base(DefaultMessage) { }

    public InvalidDateTimeException(string message) : base(message) { }
}