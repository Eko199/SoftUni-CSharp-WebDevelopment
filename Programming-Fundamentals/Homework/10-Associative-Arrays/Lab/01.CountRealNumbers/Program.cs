using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            foreach (int num in nums)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;
                else
                    counts[num] = 1;
            }

            foreach (var keyValuePair in counts)
            {
                Console.WriteLine($"{keyValuePair.Key} -> {keyValuePair.Value}");
            }
        }
    }
}
