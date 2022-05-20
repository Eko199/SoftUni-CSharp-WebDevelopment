using System;

namespace Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            int coins = 0;

            while (change > 0)
            {
                if (change >= 2)
                    change -= 2;
                else if (change >= 1)
                    change--;
                else if (change >= 0.5)
                    change -= 0.5;
                else if (change >= 0.2)
                    change -= 0.2;
                else if (change >= 0.1)
                    change -= 0.1;
                else if (change >= 0.05)
                    change -= 0.05;
                else if (change >= 0.02)
                    change -= 0.02;
                else
                    change -= 0.01;
                change = Math.Round(change, 2);
                coins++;
            }

            Console.WriteLine(coins);
        }
    }
}
