namespace Logger.Core.IO;

using Contracts;
using Enums;
using Models;
using Models.Contracts;

public class FileAppender : IAppender
{
    public FileAppender(ILayout layout, ILogFile file)
    {
        Layout = layout;
        LogFile = file;
        AppendedMessages = 0;
    }

    public int AppendedMessages { get; private set; }
    public ReportLevel ReportLevel { get; set; } = ReportLevel.Info;
    public ILayout Layout { get; }
    public ILogFile LogFile { get; }

    public void Append(IMessage message)
    {
        if (message.ReportLevel < ReportLevel) return;

        LogFile.Write(MessageFormatter.FormatMessage(message, Layout));
        LogFile.SaveContent();
        AppendedMessages++;
    }
}