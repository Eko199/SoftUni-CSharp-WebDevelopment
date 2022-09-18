using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float[] input = Console.ReadLine().Split().Select(float.Parse).ToArray();
            var numberOccurrences = new Dictionary<float, int>();

            foreach (float number in input)
            {
                if (!numberOccurrences.ContainsKey(number))
                    numberOccurrences.Add(number, 0);
                numberOccurrences[number]++;
            }

            foreach (var (number, count) in numberOccurrences)
            {
                Console.WriteLine($"{number} - {count} times");
            }
        }
    }
}
