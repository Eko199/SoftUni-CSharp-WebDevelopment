using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                string[] commands = input.Split();
                switch (commands[0])
                {
                    case "exchange":
                        Exchange(arr, int.Parse(commands[1]));
                        break;

                    case "max":
                        int maxIndex = MaxIndex(arr, commands[1]);
                        Console.WriteLine(maxIndex < 0 ? "No matches" : maxIndex.ToString());
                        break;

                    case "min":
                        int minIndex = MinIndex(arr, commands[1]);
                        Console.WriteLine(minIndex < 0 ? "No matches" : minIndex.ToString());
                        break;

                    case "first":
                        int countFirst = int.Parse(commands[1]);

                        if (countFirst > arr.Length)
                            Console.WriteLine("Invalid count");
                        else
                            PrintArray(GetFirst(arr, countFirst, commands[2]));

                        break;

                    case "last":
                        int countLast = int.Parse(commands[1]);

                        if (countLast > arr.Length)
                            Console.WriteLine("Invalid count");
                        else
                            PrintArray(GetLast(arr, countLast, commands[2]));

                        break;
                }

                input = Console.ReadLine();
            }

            PrintArray(arr);
        }

        private static void Exchange(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            List<int> newArr = arr.TakeLast(arr.Length - (index + 1)).ToList();
            newArr.AddRange(arr.Take(index + 1));
            Array.Copy(newArr.ToArray(), arr, newArr.Count);
        }

        private static int MaxIndex(int[] arr, string evenOrOdd)
        {
            int modulo2 = StringToModulo(evenOrOdd);
            int maxId = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == modulo2 && (maxId == -1 || arr[maxId] <= arr[i]))
                    maxId = i;
            }

            return maxId;
        }

        private static int MinIndex(int[] arr, string evenOrOdd)
        {
            int modulo2 = StringToModulo(evenOrOdd);
            int minId = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == modulo2 && (minId == -1 || arr[minId] >= arr[i]))
                    minId = i;
            }

            return minId;
        }

        private static int[] GetFirst(int[] arr, int count, string evenOrOdd)
        {
            int modulo2 = StringToModulo(evenOrOdd);
            return arr.Where(number => number % 2 == modulo2).Take(count).ToArray();
        }

        private static int[] GetLast(int[] arr, int count, string evenOrOdd)
        {
            int modulo2 = StringToModulo(evenOrOdd);
            return arr.Where(number => number % 2 == modulo2).TakeLast(count).ToArray();
        }

        private static int StringToModulo(string evenOrOdd) => evenOrOdd.Equals("even") ? 0 : 1;

        private static void PrintArray(int[] arr) => Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }
}
