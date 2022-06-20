using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> newList = new List<int>();
            bool fromList1 = true;
            while (Math.Min(list1.Count, list2.Count) > 0)
            {
                if (fromList1)
                {
                    newList.Add(list1[0]);
                    list1.RemoveAt(0);
                }
                else
                {
                    newList.Add(list2[0]);
                    list2.RemoveAt(0);
                }
                fromList1 = !fromList1;
            }

            newList.AddRange(list1);
            newList.AddRange(list2);

            Console.WriteLine(string.Join(" ", newList));
        }
    }
}
