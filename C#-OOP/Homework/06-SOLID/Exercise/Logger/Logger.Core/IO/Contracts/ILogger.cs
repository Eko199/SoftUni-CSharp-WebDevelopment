namespace Logger.Core.IO.Contracts;

public interface ILogger
{
    IReadOnlyCollection<IAppender> Appenders { get; }

    void AddAppender(IAppender appender);
    void Info(string dateTime, string text);
    void Warning(string dateTime, string text);
    void Error(string dateTime, string text);
    void Critical(string dateTime, string text);
    void Fatal(string dateTime, string text);
}