using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5 };
            Increment(arr);
            Console.WriteLine(arr[0]);
        }

        private static void Increment(int[] arr)
        {
            arr[0] += 5;
        }
    }
}
