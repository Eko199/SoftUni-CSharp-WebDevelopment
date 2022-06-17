using System;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintCharsBetween(char.Parse(Console.ReadLine()), char.Parse(Console.ReadLine()));
        }

        private static void PrintCharsBetween(char a, char b)
        {
            char start = (char)Math.Min(a, b);
            char end = (char)Math.Max(a, b);

            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
