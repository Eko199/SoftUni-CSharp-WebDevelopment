namespace Vehicles
{
    using Core;
    using Core.Interfaces;
    using IO;

    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());
            engine.Run();
        }
    }
}
