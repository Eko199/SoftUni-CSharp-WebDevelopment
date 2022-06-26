using System;

namespace _01.TheHuntingGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double waterPerDayAPerson = double.Parse(Console.ReadLine());
            double foodPerDayAPerson = double.Parse(Console.ReadLine());

            double food = foodPerDayAPerson * players * days, water = waterPerDayAPerson * players * days;
            for (int day = 1; day <= days; day++)
            {
                double consumedEnergy = double.Parse(Console.ReadLine());
                energy -= consumedEnergy;
                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {food:f2} food and {water:f2} water.");
                    return;
                }

                if (day % 2 == 0)
                {
                    energy *= 1.05;
                    water *= 0.7;
                }

                if (day % 3 == 0)
                {
                    food -= food / players;
                    energy *= 1.1;
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
        }
    }
}
