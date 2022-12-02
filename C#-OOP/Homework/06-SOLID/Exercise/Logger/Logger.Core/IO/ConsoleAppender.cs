namespace Logger.Core.IO;

using Contracts;
using Enums;
using Models;
using Models.Contracts;

public class ConsoleAppender : IAppender
{
    public ConsoleAppender(ILayout layout)
    {
        Layout = layout;
        AppendedMessages = 0;
    }

    public int AppendedMessages { get; private set; }
    public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;
    public ILayout Layout { get; }

    public void Append(IMessage message)
    {
        if (message.ReportLevel < ReportLevel) return;

        Console.WriteLine(MessageFormatter.FormatMessage(message, Layout));
        AppendedMessages++;
    }
}