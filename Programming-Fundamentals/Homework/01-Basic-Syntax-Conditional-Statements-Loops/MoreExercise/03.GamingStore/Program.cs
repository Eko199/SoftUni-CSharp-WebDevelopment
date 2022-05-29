using System;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double startMoney = balance;
            string input = Console.ReadLine();

            double price;
            while (input != "Game Time")
            {
                price = input switch
                {
                    "OutFall 4" => 39.99,
                    "CS: OG" => 15.99,
                    "Zplinter Zell" => 19.99,
                    "Honored 2" => 59.99,
                    "RoverWatch" => 29.99,
                    "RoverWatch Origins Edition" => 39.99,
                    _ => -1
                };

                if (price == -1)
                    Console.WriteLine("Not Found");
                else if (price <= balance)
                {
                    balance -= price;
                    Console.WriteLine($"Bought {input}");
                }
                else
                    Console.WriteLine("Too Expensive");

                if (balance == 0) break;
                input = Console.ReadLine();
            }

            Console.WriteLine(balance == 0 ? "Out of money!" : $"Total spent: ${startMoney - balance:f2}. Remaining: ${balance:f2}");
        }
    }
}
