using System;
using System.Linq;

namespace CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(arr, (x, y) => {
                if (x % 2 == 0 && y % 2 != 0)
                    return -1;

                if (x % 2 != 0 && y % 2 == 0)
                    return 1;

                return x.CompareTo(y);
            });

            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
