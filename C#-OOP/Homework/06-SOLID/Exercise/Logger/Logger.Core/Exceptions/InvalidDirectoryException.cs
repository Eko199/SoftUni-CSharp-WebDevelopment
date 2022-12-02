namespace Logger.Core.Exceptions;

public class InvalidDirectoryException : Exception
{
    private const string DefaultMessage = "Directory does not exist!";

    public InvalidDirectoryException() : base(DefaultMessage) { }

    public InvalidDirectoryException(string message) : base(message) { }
}