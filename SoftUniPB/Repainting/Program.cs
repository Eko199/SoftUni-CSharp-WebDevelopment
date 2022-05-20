using System;

namespace Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int diluent = int.Parse(Console.ReadLine());
            int hoursWork = int.Parse(Console.ReadLine());

            double nylonPrice = (nylon + 2) * 1.5;
            double paintPrice = (paint * 1.1) * 14.5;
            double diluentPrice = diluent * 5;
            double bagPrice = 0.4;

            double materialPrice = nylonPrice + paintPrice + diluentPrice + bagPrice;
            double workPrice = materialPrice * 0.3;
            double price = materialPrice + workPrice * hoursWork;
            Console.WriteLine(price);
        }
    }
}
