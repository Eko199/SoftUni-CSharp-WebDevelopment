using System;

namespace SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string grade = Console.ReadLine();

            double price = days - 1;
            switch (room)
            {
                case "room for one person":
                    price *= 18;
                    break;
                case "apartment":
                    price *= 25;
                    if (days < 10)
                        price *= 0.7;
                    else if (days <= 15)
                        price *= 0.65;
                    else
                        price *= 0.5;
                    break;
                case "president apartment":
                    price *= 35;
                    if (days < 10)
                        price *= 0.9;
                    else if (days <= 15)
                        price *= 0.85;
                    else
                        price *= 0.8;
                    break;
            }

            if (grade == "positive")
                price *= 1.25;
            else if (grade == "negative")
                price *= 0.9;

            Console.WriteLine($"{price:f2}");
        }
    }
}
