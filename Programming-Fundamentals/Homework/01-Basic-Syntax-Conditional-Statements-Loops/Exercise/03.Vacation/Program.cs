using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            switch (group)
            {
                case "Students":
                    if (day == "Friday")
                        price = 8.45;
                    else if (day == "Saturday")
                        price = 9.8;
                    else if (day == "Sunday")
                        price = 10.46;

                    if (people >= 30)
                        price *= 0.85;

                    break;
                case "Business":
                    if (day == "Friday")
                        price = 10.9;
                    else if (day == "Saturday")
                        price = 15.6;
                    else if (day == "Sunday")
                        price = 16;

                    if (people >= 100)
                        people -= 10;

                    break;
                case "Regular":
                    if (day == "Friday")
                        price = 15;
                    else if (day == "Saturday")
                        price = 20;
                    else if (day == "Sunday")
                        price = 22.5;

                    if (10 <= people && people <= 20)
                        price *= 0.95;

                    break;
            }

            price *= people;
            Console.WriteLine( $"Total price: {price:f2}");
        }
    }
}
