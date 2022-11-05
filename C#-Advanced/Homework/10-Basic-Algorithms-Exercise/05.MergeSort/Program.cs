using System;
using System.Linq;

namespace _05.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MergeSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(' ', arr));
        }

        public static void MergeSort<T>(T[] arr, int left, int right) where T : IComparable<T>
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }

        private static void Merge<T>(T[] arr, int left, int mid, int right) where T : IComparable<T>
        {
            T[] lArr = arr[left..(mid+1)];
            T[] rArr = arr[(mid+1)..(right+1)];

            int lIndex = 0, rIndex = 0, arrIndex = left;
            while (lIndex < lArr.Length && rIndex < rArr.Length)
            {
                arr[arrIndex++] = lArr[lIndex].CompareTo(rArr[rIndex]) <= 0 ? lArr[lIndex++] : rArr[rIndex++];
            }

            while (lIndex < lArr.Length)
                arr[arrIndex++] = lArr[lIndex++];
            while (rIndex < rArr.Length)
                arr[arrIndex++] = rArr[rIndex++];
        }
    }
}
