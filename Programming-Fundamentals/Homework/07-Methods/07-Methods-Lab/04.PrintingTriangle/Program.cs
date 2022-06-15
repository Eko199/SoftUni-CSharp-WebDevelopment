using System;

namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());

            for (int i = 1; i <= height; i++)
            {
                PrintLine(i);
            }

            for (int i = 1; i < height; i++)
            {
                PrintLine(height - i);
            }
        }

        static void PrintLine(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
