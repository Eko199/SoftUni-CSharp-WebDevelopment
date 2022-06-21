using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());    
            }

            products.Sort();
            foreach (var product in products)
            {
                Console.WriteLine(products.IndexOf(product) + 1 + "." + product);
            }
        }
    }
}
