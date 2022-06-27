using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> initialQualities = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> qualities = new List<int>(initialQualities);

            string input = Console.ReadLine();
            while (!input.Equals("Hit it again, Gabsy!"))
            {
                int power = int.Parse(input);

                for (int i = 0; i < qualities.Count; i++)
                {
                    if (qualities[i] <= 0) continue;

                    qualities[i] -= power;
                    if (qualities[i] > 0) continue;

                    double price = initialQualities[i] * 3;
                    if (savings >= price)
                    {
                        qualities[i] = initialQualities[i];
                        savings -= price;
                    }
                }

                input = Console.ReadLine();
            }

            qualities.RemoveAll(drum => drum <= 0);
            Console.WriteLine(string.Join(' ', qualities));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
