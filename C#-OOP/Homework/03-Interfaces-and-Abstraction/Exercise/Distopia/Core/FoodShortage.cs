namespace Distopia.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using Models.Interfaces;

    public class FoodShortage : IEngine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            var buyers = new Dictionary<string, IBuyer>(n);
            
            for (int i = 0; i < n; i++)
            {
                string[] buyer = Console.ReadLine().Split();

                buyers.Add(buyer[0], buyer.Length switch
                {
                    4 => new Citizen(buyer[0], int.Parse(buyer[1]), buyer[2], buyer[3]),
                    3 => new Rebel(buyer[0], int.Parse(buyer[1]), buyer[2])
                });
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (!buyers.ContainsKey(command))
                    continue;

                buyers[command].BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Value.Food));
        }
    }
}
