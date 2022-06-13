using System;

namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int rotations = int.Parse(Console.ReadLine());

            rotations %= arr.Length;
            for (int i = 0; i < rotations; i++)
            {
                string temp = arr[0];
                for (int j = 0; j < arr.Length; j++)
                {
                    if (j + 1 < arr.Length)
                    {
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                    else
                    {
                        arr[j] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
