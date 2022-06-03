using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalYield = 0, days = 0;

            while (yield >= 100)
            {
                days++;
                totalYield += yield - 26;
                yield -= 10;
            }

            totalYield = (totalYield >= 26) ? totalYield - 26 : 0;
            Console.WriteLine(days);
            Console.WriteLine(totalYield);
        }
    }
}
