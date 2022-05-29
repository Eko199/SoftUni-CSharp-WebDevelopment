using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = 0;
            string input = Console.ReadLine();

            while (input != "Start")
            {
                switch (input)
                {
                    case "0.1":
                    case "0.2":
                    case "0.5":
                    case "1":
                    case "2":
                        money += double.Parse(input);
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {input}");
                        break;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                double price = input switch
                {
                    "Nuts" => 2,
                    "Water" => 0.7,
                    "Crisps" => 1.5,
                    "Soda" => 0.8,
                    "Coke" => 1,
                    _ => -1
                };

                if (price == -1)
                    Console.WriteLine("Invalid product");
                else if (money >= price)
                {
                    money -= price;
                    Console.WriteLine("Purchased " + input.ToLower());
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
