using System;

namespace PCStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cpuPrice = double.Parse(Console.ReadLine());
            double gpuPrice = double.Parse(Console.ReadLine());
            double ramPrice = double.Parse(Console.ReadLine());
            int rams = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double priceDollars = (cpuPrice + gpuPrice) * (1 - discount) + ramPrice * rams;
            double priceLeva = priceDollars * 1.57;
            Console.WriteLine($"Money needed - {priceLeva:f2} leva.");
        }
    }
}
