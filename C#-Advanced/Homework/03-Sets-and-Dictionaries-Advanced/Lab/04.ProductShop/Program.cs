using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productShops = new SortedDictionary<string, Dictionary<string, float>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] tokens = input.Split(", ");

                if (!productShops.ContainsKey(tokens[0]))
                    productShops.Add(tokens[0], new Dictionary<string, float>());

                productShops[tokens[0]][tokens[1]] = float.Parse(tokens[2]);
                input = Console.ReadLine();
            }

            foreach ((string shop, Dictionary<string, float> products) in productShops)
            {
                Console.WriteLine($"{shop}->");
                Console.WriteLine(string.Join(Environment.NewLine, 
                    products.Select(pair => $"Product: {pair.Key}, Price: {pair.Value}")));
            }
        }
    }
}
