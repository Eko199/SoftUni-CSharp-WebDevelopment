using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = arr => arr.Select(x => x + 1).ToArray();
            Func<int[], int[]> multiply = arr => arr.Select(x => x * 2).ToArray();
            Func<int[], int[]> subtract = arr => arr.Select(x => x - 1).ToArray();
            Action<int[]> print = arr => Console.WriteLine(string.Join(' ', arr));

            string input = Console.ReadLine();
            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        arr = add(arr);
                        break;
                    case "subtract":
                        arr = subtract(arr);
                        break;
                    case "multiply":
                        arr = multiply(arr);
                        break;
                    case "print":
                        print(arr);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
