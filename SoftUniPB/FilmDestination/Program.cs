using System;

namespace FilmDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double dayPrice = 0;
            switch (destination)
            {
                case "Dubai":
                    if (season == "Winter")
                        dayPrice = 45000;
                    else if (season == "Summer")
                        dayPrice = 40000;
                    dayPrice *= 0.7;
                    break;
                case "Sofia":
                    if (season == "Winter")
                        dayPrice = 17000;
                    else if (season == "Summer")
                        dayPrice = 12500;
                    dayPrice *= 1.25;
                    break;
                case "London":
                    if (season == "Winter")
                        dayPrice = 24000;
                    else if (season == "Summer")
                        dayPrice = 20250;
                    break;
            }
            double price = dayPrice * days;

            if (budget >= price)
                Console.WriteLine($"The budget for the movie is enough! We have {budget - price:f2} leva left!");
            else
                Console.WriteLine($"The director needs {price - budget:f2} leva more!");
        }
    }
}
