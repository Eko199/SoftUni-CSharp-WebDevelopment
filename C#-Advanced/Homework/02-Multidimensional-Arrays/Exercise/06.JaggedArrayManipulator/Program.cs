using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];

            for (int row = 0; row < arr.Length; row++)
                arr[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int row = 0; row < arr.Length - 1; row++)
            {
                if (arr[row].Length == arr[row + 1].Length)
                {
                    arr[row] = arr[row].Select(x => x * 2).ToArray();
                    arr[row + 1] = arr[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    arr[row] = arr[row].Select(x => x / 2).ToArray();
                    arr[row + 1] = arr[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]), col = int.Parse(tokens[2]), value = int.Parse(tokens[3]);

                if (row >= 0 && row < arr.Length && col >= 0 && col < arr[row].Length)
                {
                    switch (action)
                    {
                        case "Add":
                            arr[row][col] += value;
                            break;
                        case "Subtract":
                            arr[row][col] -= value;
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (int[] row in arr)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
