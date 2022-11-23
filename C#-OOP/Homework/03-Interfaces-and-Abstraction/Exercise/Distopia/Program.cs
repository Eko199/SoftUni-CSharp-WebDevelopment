namespace Distopia
{
    using Core;
    using Core.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new FoodShortage();
            engine.Run();
        }
    }
}
