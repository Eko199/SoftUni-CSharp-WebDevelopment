using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            const int CAPACITY = 255;

            int spaceLeft = CAPACITY;
            for (int i = 0; i < n; i++)
            {
                int litters = int.Parse(Console.ReadLine());
                if (spaceLeft >= litters)
                    spaceLeft -= litters;
                else
                    Console.WriteLine("Insufficient capacity!");
            }

            Console.WriteLine(CAPACITY - spaceLeft);
        }
    }
}
