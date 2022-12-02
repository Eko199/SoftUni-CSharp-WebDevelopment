namespace Logger.Core.Exceptions;

public class EmptyMessageContentException : Exception
{
    private const string DefaultMessage = "Message content cannot be empty or white space!";

    public EmptyMessageContentException() : base(DefaultMessage) { }

    public EmptyMessageContentException(string message) : base(message) { }
}