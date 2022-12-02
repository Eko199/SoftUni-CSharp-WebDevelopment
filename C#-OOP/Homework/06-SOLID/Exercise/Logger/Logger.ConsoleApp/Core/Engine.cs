namespace Logger.ConsoleApp.Core;

using Contracts;
using Factories.Contracts;

using Logger.Core.Enums;
using Logger.Core.IO;
using Logger.Core.IO.Contracts;
using Logger.Core.Models.Contracts;

public class Engine : IEngine
{
    private readonly ILayoutFactory layoutFactory;
    private readonly IAppenderFactory appenderFactory;
    private readonly ILogger logger;

    public Engine(ILayoutFactory layoutFactory, IAppenderFactory appenderFactory)
    {
        this.layoutFactory = layoutFactory;
        this.appenderFactory = appenderFactory;
        logger = new Logger();
    }

    public void Run()
    {
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            try
            {
                AddAppender();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                i--;
            }
        }

        string command;
        while ((command = Console.ReadLine()!) != "END")
        {
            try
            {
                LogMessage(command);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        PrintLoggerInfo();
    }

    private void AddAppender()
    {
        string[] cmdArgs = Console.ReadLine()!.Split();

        ILayout layout = layoutFactory.CreateLayout(cmdArgs[1]);

        IAppender appender;
        if (cmdArgs.Length == 3)
        {
            if (!Enum.TryParse(cmdArgs[2], true, out ReportLevel reportLevel))
                throw new ArgumentException($"{cmdArgs[2]} is not a valid report level!");

            appender = appenderFactory.CreateAppender(cmdArgs[0], layout, reportLevel);
        }
        else
        {
            appender = appenderFactory.CreateAppender(cmdArgs[0], layout);
        }

        logger.AddAppender(appender);
    }

    private void LogMessage(string command)
    {
        string[] messageInfo = command.Split('|');
        
        switch (messageInfo[0])
        {
            case "INFO":
                logger.Info(messageInfo[1], messageInfo[2]);
                break;
            case "WARNING":
                logger.Warning(messageInfo[1], messageInfo[2]);
                break;
            case "ERROR":
                logger.Error(messageInfo[1], messageInfo[2]);
                break;
            case "CRITICAL":
                logger.Critical(messageInfo[1], messageInfo[2]);
                break;
            case "FATAL":
                logger.Fatal(messageInfo[1], messageInfo[2]);
                break;
            default:
                throw new ArgumentException($"{messageInfo[0]} is not a valid report level!");
        }
    }

    private void PrintLoggerInfo()
    {
        Console.WriteLine("Logger info");

        foreach (IAppender appender in logger.Appenders)
        {
            Console.WriteLine(
                $"Appender type: {appender.GetType().Name}, " +
                $"Layout type: {appender.Layout.GetType().Name}, " +
                $"Report level: {appender.ReportLevel}, " +
                $"Messages appended: {appender.AppendedMessages}" + 
                (appender is FileAppender fileAppender ? $", File size: {fileAppender.LogFile.Size}" : string.Empty));
        }
    }
}