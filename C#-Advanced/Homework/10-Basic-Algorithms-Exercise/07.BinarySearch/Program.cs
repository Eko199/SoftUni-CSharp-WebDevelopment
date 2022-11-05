using System;
using System.Linq;

namespace _07.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IndexOf(Console.ReadLine().Split().Select(int.Parse).ToArray(), int.Parse(Console.ReadLine())));
        }

        private static int IndexOf(int[] arr, int n)
        {
            int start = 0, end = arr.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (n < arr[mid])
                    end = mid - 1;
                else if (n > arr[mid])
                    start = mid + 1;
                else
                    return mid;
            }

            return -1;
        }
    }
}
