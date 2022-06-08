using System;

namespace _03.FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Abs(a - b) < 0.000001);
        }
    }
}
