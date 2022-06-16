using System;

namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRectangleArea(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));
        }

        static double GetRectangleArea(double a, double b)
        {
            return a * b;
        }
    }
}
