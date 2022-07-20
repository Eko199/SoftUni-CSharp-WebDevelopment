using System;

namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double result = 0;
            foreach (string item in items)
            {
                double number = int.Parse(item.Substring(1, item.Length - 2));
                int position1 = char.ToLower(item[0]) - 'a' + 1;
                int position2 = char.ToLower(item[^1]) - 'a' + 1;

                if (char.IsUpper(item[0]))
                    number /= position1;
                else
                    number *= position1;

                if (char.IsUpper(item[^1]))
                    number -= position2;
                else
                    number += position2;

                result += number;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}
