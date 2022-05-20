using System;

namespace FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine()) / 100;

            double volume = length * width * height / 1000.0;
            Console.WriteLine(volume * (1 - percent));
        }
    }
}
