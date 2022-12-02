namespace Logger.Core.Models;

using Contracts;
using Enums;
using Exceptions;
using System.Globalization;

public class Message : IMessage
{
    private readonly string? content;
    private DateTime dateTime;

    public Message(string content, ReportLevel reportLevel, string dateTime)
    {
        Content = content;
        ReportLevel = reportLevel;
        SetDateTime(dateTime);
    }

    public string Content
    {
        get => content!;
        private init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new EmptyMessageContentException();

            content = value;
        }
    }

    public ReportLevel ReportLevel { get; }
    public DateTime DateTime => dateTime;

    private void SetDateTime(string dateTimeStr)
    {
        if (!DateTime.TryParse(dateTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            throw new InvalidDateTimeException($"Invalid Date and Time: {dateTimeStr}");
    }
}