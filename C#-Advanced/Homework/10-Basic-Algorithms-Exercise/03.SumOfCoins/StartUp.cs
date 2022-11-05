using System;
using System.Linq;

namespace SumOfCoins
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, int> coins = ChooseCoins(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList(), int.Parse(Console.ReadLine()));

            Console.WriteLine($"Number of coins to take: {coins.Sum(coin => coin.Value)}");
            foreach (var coin in coins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int, int> result = coins.OrderByDescending(coin => coin).ToDictionary(coin => coin, coin => 0);

            foreach (var coinAmount in result)
            {
                while (targetSum >= coinAmount.Key)
                {
                    result[coinAmount.Key]++;
                    targetSum -= coinAmount.Key;
                }
            }

            if (targetSum != 0)
                throw new InvalidOperationException();

            return result
                .Where(coin => coin.Value > 0)
                .ToDictionary(coin => coin.Key, coin => coin.Value);
        }
    }
}