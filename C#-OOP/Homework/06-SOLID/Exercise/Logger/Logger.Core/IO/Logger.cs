namespace Logger.Core.IO;

using Contracts;
using Enums;
using Models;
using Models.Contracts;

public class Logger : ILogger
{
    private readonly ICollection<IAppender> appenders;

    public Logger(params IAppender[] appenders)
    {
        this.appenders = appenders.ToList();
    }

    public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)appenders;

    public void AddAppender(IAppender appender)
        => appenders.Add(appender);

    public void Info(string dateTime, string text)
        => Log(dateTime, text, ReportLevel.Info);

    public void Warning(string dateTime, string text)
        => Log(dateTime, text, ReportLevel.Warning);

    public void Error(string dateTime, string text)
        => Log(dateTime, text, ReportLevel.Error);

    public void Critical(string dateTime, string text)
        => Log(dateTime, text, ReportLevel.Critical);

    public void Fatal(string dateTime, string text)
        => Log(dateTime, text, ReportLevel.Fatal);

    private void Log(string dateTime, string text, ReportLevel reportLevel)
    {
        IMessage message = new Message(text, reportLevel, dateTime);

        foreach (IAppender appender in appenders)
        {
            appender.Append(message);
        }
    }
}