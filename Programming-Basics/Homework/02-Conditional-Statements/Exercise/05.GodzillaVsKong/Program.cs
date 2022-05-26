using System;

namespace GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double dressPrice = double.Parse(Console.ReadLine());

            double needed = budget * 0.1;
            if (statists <= 150)
                needed += statists * dressPrice;
            else
                needed += statists * dressPrice * 0.9;

            if (budget >= needed)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - needed):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(needed - budget):F2} leva more.");
            }
        }
    }
}
