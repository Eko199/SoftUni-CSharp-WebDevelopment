using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ArrSum(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }

        public static int ArrSum(int[] arr)
            => arr[0] + (arr.Length == 1 ? 0 : ArrSum(arr[1..]));
    }
}
