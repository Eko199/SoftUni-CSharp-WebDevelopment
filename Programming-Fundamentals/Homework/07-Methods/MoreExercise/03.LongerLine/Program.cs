using System;

namespace _03.LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double length1 = GetLength(x1, y1, x2, y2);
            double length2 = GetLength(x3, y3, x4, y4);
            PrintLine(length1 >=  length2 
                ? (GetLength(x1, y1, 0, 0) <= GetLength(x2, y2, 0, 0) 
                    ? (x1, y1, x2, y2) : (x2, y2, x1, y1)) 
                : (GetLength(x3, y3, 0, 0) <= GetLength(x4, y4, 0, 0)
                    ? (x3, y3, x4, y4) : (x4, y4, x3, y3)));
        }

        private static double GetLength(double x1, double y1, double x2, double y2)
            => Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));

        private static void PrintLine((double, double, double, double) line)
            => Console.WriteLine($"({line.Item1}, {line.Item2})({line.Item3}, {line.Item4})");
    }
}
