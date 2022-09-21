using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var occurrences = new Dictionary<int, int>(n);

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!occurrences.ContainsKey(num))
                    occurrences[num] = 0;

                occurrences[num]++;
            }

            Console.WriteLine(occurrences.First(pair => pair.Value % 2 == 0).Key);
        }
    }
}
