using System;

namespace ExcursionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double personPrice = 0;
            switch (season)
            {
                case "spring":
                    if (people <= 5)
                        personPrice = 50;
                    else
                        personPrice = 48;
                    break;
                case "summer":
                    if (people <= 5)
                        personPrice = 48.5;
                    else
                        personPrice = 45;
                    personPrice *= 0.85;
                    break;
                case "autumn":
                    if (people <= 5)
                        personPrice = 60;
                    else
                        personPrice = 49.5;
                    break;
                case "winter":
                    if (people <= 5)
                        personPrice = 86;
                    else
                        personPrice = 85;
                    personPrice *= 1.08;
                    break;
            }

            Console.WriteLine($"{personPrice * people:f2} leva.");
        }
    }   
}
