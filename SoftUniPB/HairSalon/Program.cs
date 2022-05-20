using System;

namespace HairSalon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int earned = 0;

            while (input != "closed" && earned < target)
            {
                string option = Console.ReadLine();
                if (input == "haircut")
                {
                    switch (option)
                    {
                        case "mens":
                            earned += 15;
                            break;
                        case "ladies":
                            earned += 20;
                            break;
                        case "kids":
                            earned += 10;
                            break;
                    }
                }
                else if (input == "color")
                {
                    switch (option)
                    {
                        case "touch up":
                            earned += 20;
                            break;
                        case "full color":
                            earned += 30;
                            break;
                    }
                }

                input = Console.ReadLine();
            }

            if (earned >= target)
                Console.WriteLine("You have reached your target for the day!");
            else
                Console.WriteLine($"Target not reached! You need {target-earned}lv. more.");
            Console.WriteLine($"Earned money: {earned}lv.");
        }
    }
}
