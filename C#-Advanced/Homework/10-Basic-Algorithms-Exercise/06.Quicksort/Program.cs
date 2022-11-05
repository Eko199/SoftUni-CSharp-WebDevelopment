using System;
using System.Linq;

namespace _06.Quicksort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(' ', arr));
        }

        public static void QuickSort<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            if (start >= end) return;

            int pivotIndex = Partition(arr, start, end);

            QuickSort(arr, 0, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, end);
        }

        private static int Partition<T>(T[] arr, int start, int end) where T : IComparable<T>
        {
            T pivot = arr[end];
            int index = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i].CompareTo(pivot) <= 0)
                {
                    (arr[i], arr[index]) = (arr[index++], arr[i]);
                }
            }

            (arr[end], arr[index]) = (arr[index], arr[end]);
            return index;
        }
    }
}
