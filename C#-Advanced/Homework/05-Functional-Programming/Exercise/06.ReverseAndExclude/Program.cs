using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverse = array =>
            {
                int[] newArr = new int[array.Length];

                for (int i = 0; i < newArr.Length; i++)
                {
                    newArr[i] = array[^(i + 1)];
                }

                return newArr;
            };

            Predicate<int> isNotDivisible = n => n % divisor != 0;

            Func<int[], Predicate<int>, int[]> exclude = (array, predicate) => Array.FindAll(array, predicate);

            arr = exclude(reverse(arr), isNotDivisible);
            Console.WriteLine(string.Join(' ', arr));
        }
    }
}
