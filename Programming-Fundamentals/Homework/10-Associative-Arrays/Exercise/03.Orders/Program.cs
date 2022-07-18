using System;
using System.Collections.Generic;

namespace _03.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, List<double>>();

            string order = Console.ReadLine();
            while (order != "buy")
            {
                string[] tokens = order.Split();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!products.ContainsKey(tokens[0]))
                    products.Add(tokens[0], new List<double> {price, quantity});
                else
                {
                    products[product][0] = price;
                    products[product][1] += quantity;
                }

                order = Console.ReadLine();
            }

            foreach (var (product, priceAndQuantity) in products)
            {
                Console.WriteLine($"{product} -> {priceAndQuantity[0] * priceAndQuantity[1] :f2}");
            }
        }
    }
}
