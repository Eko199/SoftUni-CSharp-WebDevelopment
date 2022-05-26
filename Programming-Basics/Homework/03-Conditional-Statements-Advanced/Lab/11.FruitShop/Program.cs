using System;

namespace FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            int weekDay = 0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    weekDay = 1;
                    break;
                case "Saturday":
                case "Sunday":
                    weekDay = -1;
                    break;
            }

            double price = 0;
            switch (fruit)
            {
                case "banana":
                    if (weekDay == 1)
                        price = 2.5;
                    else if (weekDay == -1)
                        price = 2.7;
                    break;
                case "apple":
                    if (weekDay == 1)
                        price = 1.2;
                    else if (weekDay == -1)
                        price = 1.25;
                    break;
                case "orange":
                    if (weekDay == 1)
                        price = 0.85;
                    else if (weekDay == -1)
                        price = 0.9;
                    break;
                case "grapefruit":
                    if (weekDay == 1)
                        price = 1.45;
                    else if (weekDay == -1)
                        price = 1.6;
                    break;
                case "kiwi":
                    if (weekDay == 1)
                        price = 2.7;
                    else if (weekDay == -1)
                        price = 3;
                    break;
                case "pineapple":
                    if (weekDay == 1)
                        price = 5.5;
                    else if (weekDay == -1)
                        price = 5.6;
                    break;
                case "grapes":
                    if (weekDay == 1)
                        price = 3.85;
                    else if (weekDay == -1)
                        price = 4.2;
                    break;
            }

            if (price != 0)
                Console.WriteLine($"{(quantity * price):f2}");
            else
                Console.WriteLine("error");
        }
    }
}
