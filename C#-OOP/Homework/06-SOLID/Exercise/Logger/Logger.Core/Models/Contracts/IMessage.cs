namespace Logger.Core.Models.Contracts;

using Enums;

public interface IMessage
{
    string Content { get; }
    ReportLevel ReportLevel { get; }
    DateTime DateTime { get; }
}