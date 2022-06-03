using System;

namespace _08.BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestModel = "";
            double biggestVolume = -1;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double volume = Math.PI * Math.Pow(double.Parse(Console.ReadLine()), 2) * int.Parse(Console.ReadLine());

                if (i == 0 || volume > biggestVolume)
                {
                    biggestModel = model;
                    biggestVolume = volume;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
