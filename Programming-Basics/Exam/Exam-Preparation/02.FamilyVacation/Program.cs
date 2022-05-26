using System;

namespace FamilyVacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double nightPrice = double.Parse(Console.ReadLine());
            int percentCosts = int.Parse(Console.ReadLine());

            if (nights > 7)
                nightPrice *= 0.95;
            double price = nights * nightPrice;
            budget *= 1 - percentCosts / 100.0;

            if (budget >= price)
                Console.WriteLine($"Ivanovi will be left with {budget - price:f2} leva after vacation.");
            else
                Console.WriteLine($"{price - budget:f2} leva needed.");
        }
    }
}
