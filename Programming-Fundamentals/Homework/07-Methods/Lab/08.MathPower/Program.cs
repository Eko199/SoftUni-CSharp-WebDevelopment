using System;

namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RaiseToPower(double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }

        static double RaiseToPower(double @base, int power)
        {
            return Math.Pow(@base, power);
        }
    }
}
