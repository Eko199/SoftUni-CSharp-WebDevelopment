namespace Logger.Core.Models;

using Contracts;

internal static class MessageFormatter
{
    public static string DateTimeFormat = "MM/dd/yyyy hh:mm:ss tt";

    public static string FormatMessage(IMessage message, ILayout layout)
        => string.Format(layout.Format, message.DateTime.ToString(DateTimeFormat), message.ReportLevel, message.Content);
}