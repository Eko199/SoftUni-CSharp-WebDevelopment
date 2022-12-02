namespace Logger.ConsoleApp.Factories.Contracts;

using Logger.Core.Enums;
using Logger.Core.IO.Contracts;
using Logger.Core.Models.Contracts;

public interface IAppenderFactory
{
    IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = ReportLevel.Info);
}