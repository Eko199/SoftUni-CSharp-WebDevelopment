namespace Logger.Core.Exceptions;

public class EmptyFileNameException : Exception
{
    private const string DefaultMessage = "LogFile name cannot be empty or white space!";

    public EmptyFileNameException() : base(DefaultMessage) { }

    public EmptyFileNameException(string message) : base(message) { }
}