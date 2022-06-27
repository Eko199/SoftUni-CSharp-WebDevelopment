using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int lesserCount = Math.Min(list1.Count, list2.Count);
            for (int i = 0; i < lesserCount; i++)
            {
                result.Add(list1[0]);
                list1.RemoveAt(0);
                result.Add(list2[^1]);
                list2.RemoveAt(list2.Count - 1);
            }

            int lowerBound, upperBound;
            if (list1.Count > 0)
            {
                lowerBound = Math.Min(list1[0], list1[1]);
                upperBound = Math.Max(list1[0], list1[1]);
            }
            else
            {
                lowerBound = Math.Min(list2[0], list2[1]);
                upperBound = Math.Max(list2[0], list2[1]);
            }

            result.RemoveAll(num => num <= lowerBound || num >= upperBound);
            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
