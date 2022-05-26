using System;

namespace EasterEggFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEggs = int.Parse(Console.ReadLine());
            int secondEggs = int.Parse(Console.ReadLine());
            string winner = Console.ReadLine();

            while ((firstEggs > 0 && secondEggs > 0) && winner != "End of battle")
            {
                switch (winner)
                {
                    case "one":
                        secondEggs--;
                        break;
                    case "two":
                        firstEggs--;
                        break;
                }
                winner = Console.ReadLine();
            }

            if (firstEggs <= 0)
                Console.WriteLine($"Player one is out of eggs. Player two has {secondEggs} eggs left.");
            else if (secondEggs <= 0)
                Console.WriteLine($"Player two is out of eggs. Player one has {firstEggs} eggs left.");
            else
            {
                Console.WriteLine($"Player one has {firstEggs} eggs left.");
                Console.WriteLine($"Player two has {secondEggs} eggs left.");
            }
        }
    }
}
