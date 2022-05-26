using System;

namespace DeerOfSanta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double firstEating = double.Parse(Console.ReadLine());
            double secondEating = double.Parse(Console.ReadLine());
            double thirdEating = double.Parse(Console.ReadLine());

            double leftFood = food - (firstEating + secondEating + thirdEating) * days;
            if (leftFood >= 0)
                Console.WriteLine($"{Math.Floor(leftFood)} kilos of food left.");
            else
                Console.WriteLine($"{Math.Ceiling(-leftFood)} more kilos of food are needed.");
        }
    }
}
