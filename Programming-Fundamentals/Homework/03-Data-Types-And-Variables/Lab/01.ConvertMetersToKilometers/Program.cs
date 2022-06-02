using System;

namespace _01.ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters / 1000d;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}