using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpus = int.Parse(Console.ReadLine());
            int cpus = int.Parse(Console.ReadLine());
            int rams = int.Parse(Console.ReadLine());

            double gpuPrice = gpus * 250;
            double needed = gpuPrice + cpus * gpuPrice * 0.35 + rams * gpuPrice * 0.1;
            if (gpus > cpus)
                needed *= 0.85;

            if (budget >= needed)
                Console.WriteLine($"You have {(budget - needed):F2} leva left!");
            else
                Console.WriteLine($"Not enough money! You need {(needed - budget):F2} leva more!");
        }
    }
}
