using System;

namespace NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0;
            switch (flowers)
            {
                case "Roses":
                    price = number * 5;
                    if (number > 80)
                        price *= 0.9;
                    break;
                case "Dahlias":
                    price = number * 3.8;
                    if (number > 90)
                        price *= 0.85;
                    break;
                case "Tulips":
                    price = number * 2.8;
                    if (number > 80)
                        price *= 0.85;
                    break;
                case "Narcissus":
                    price = number * 3;
                    if (number < 120)
                        price *= 1.15;
                    break;
                case "Gladiolus":
                    price = number * 2.5;
                    if (number < 80)
                        price *= 1.2;
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {number}" +
                    $" {flowers} and {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
            }
        }
    }
}
