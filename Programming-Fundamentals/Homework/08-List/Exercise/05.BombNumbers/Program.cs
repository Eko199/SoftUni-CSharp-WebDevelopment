using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != bombAndPower[0]) continue;

                for (int j = 0; j < bombAndPower[1]; j++)
                {
                    if (i - 1 >= 0)
                        numbers.RemoveAt(--i);
                    if (i + 1 < numbers.Count)
                        numbers.RemoveAt(i + 1);
                }

                numbers.RemoveAt(i--);
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
