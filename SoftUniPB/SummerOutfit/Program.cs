using System;

namespace SummerOutfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string dress = "";
            string shoes = "";
            switch (time)
            {
                case "Morning":
                    if (10 <= degrees && degrees <= 18)
                    {
                        dress = "Sweatshirt";
                        shoes = "Sneakers";
                    }
                    else if (18 < degrees && degrees <= 24)
                    {
                        dress = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (degrees >= 25)
                    {
                        dress = "T-Shirt";
                        shoes = "Sandals";
                    }
                    break;
                case "Afternoon":
                    if (10 <= degrees && degrees <= 18)
                    {
                        dress = "Shirt";
                        shoes = "Moccasins";
                    }
                    else if (18 < degrees && degrees <= 24)
                    {
                        dress = "T-Shirt";
                        shoes = "Sandals";
                    }
                    else if (degrees >= 25)
                    {
                        dress = "Swim Suit";
                        shoes = "Barefoot";
                    }
                    break;
                case "Evening":
                    dress = "Shirt";
                    shoes = "Moccasins";
                    break;
            }

            Console.WriteLine($"It's {degrees} degrees, get your {dress} and {shoes}.");
        }
    }
}
