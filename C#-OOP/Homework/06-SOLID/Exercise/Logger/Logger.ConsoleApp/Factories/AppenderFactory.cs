namespace Logger.ConsoleApp.Factories;

using Contracts;

using Logger.Core.Enums;
using Logger.Core.IO;
using Logger.Core.IO.Contracts;
using Logger.Core.Models.Contracts;

public class AppenderFactory : IAppenderFactory
{
    public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
    {
        IAppender result = type switch
        {
            "ConsoleAppender" => new ConsoleAppender(layout),
            "FileAppender" => new FileAppender(layout, new LogFile()),
            _ => throw new ArgumentException($"{type} is not a valid appender type!")
        };

        result.ReportLevel = reportLevel;
        return result;
    }
}