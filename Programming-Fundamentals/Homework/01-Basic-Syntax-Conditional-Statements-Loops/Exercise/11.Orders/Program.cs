using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double total = 0;
            for (int i = 0; i < n; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                double cost = days * capsuleCount * capsulePrice;
                total += cost;
                Console.WriteLine($"The price for the coffee is: ${cost:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
