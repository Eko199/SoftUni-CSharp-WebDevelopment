using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var set1 = new HashSet<int>(nm[0]);
            for (int i = 0; i < nm[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            var set2 = new HashSet<int>(nm[1]);
            for (int i = 0; i < nm[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(' ', set1));
        }
    }
}
