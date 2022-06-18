using System;

namespace _02.CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintPoint(GetDistanceTo0(x1, y1) <= GetDistanceTo0(x2, y2) ? (x1, y1) : (x2, y2));
        }

        private static double GetDistanceTo0(double x, double y) => Math.Sqrt(x * x + y * y);

        private static void PrintPoint((double, double) point) 
            => Console.WriteLine($"({point.Item1}, {point.Item2})");
    }
}
