namespace SimpleSnake;

using System.Diagnostics;
using Core;
using GameObjects;
using Utilities;

public class StartUp
{
    public static void Main()
    {
        ConsoleWindow.CustomizeConsole();

        var wall = new Wall(60, 20);
        var engine = new Engine(wall, new Snake(wall), new Stopwatch());

        engine.Run();
    }
}