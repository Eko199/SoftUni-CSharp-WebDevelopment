using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var elementsList = new List<string>(count);

            for (int i = 0; i < count; i++)
            {
                elementsList.AddRange(Console.ReadLine().Split());
            }
            
            Console.WriteLine(string.Join(' ', new SortedSet<string>(elementsList)));
        }
    }
}
