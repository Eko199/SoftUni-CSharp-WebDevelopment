using System;

namespace ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double income = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            int items = puzzles + dolls + bears + minions + trucks;
            if (items >= 50)
                income *= 0.75;
            income *= 0.9;

            if (income >= price)
                Console.WriteLine($"Yes! {(income - price):F2} lv left.");
            else
                Console.WriteLine($"Not enough money! {(price - income):F2} lv needed.");
        }
    }
}
