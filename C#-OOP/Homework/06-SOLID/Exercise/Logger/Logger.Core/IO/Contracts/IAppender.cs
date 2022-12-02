namespace Logger.Core.IO.Contracts;

using Enums;
using Models.Contracts;

public interface IAppender
{
    int AppendedMessages { get; }
    ReportLevel ReportLevel { get; set; }
    ILayout Layout { get; }

    void Append(IMessage message);
}