namespace Logger.ConsoleApp;

using Core;
using Factories;

internal class Program
{
    static void Main(string[] args)
    {
        var engine = new Engine(new LayoutFactory(), new AppenderFactory());
        engine.Run();
    }
}