using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] arr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                arr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                string action = tokens[0];
                int row = int.Parse(tokens[1]), col = int.Parse(tokens[2]), value = int.Parse(tokens[3]);

                if (row < 0 || row >= arr.Length || col < 0 || col >= arr[row].Length)
                    Console.WriteLine("Invalid coordinates");
                else
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
