using System;

namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char c1 = (char) ('a' + i);
                for (int j = 0; j < n; j++)
                {
                    char c2 = (char) ('a' + j);
                    for (int k = 0; k < n; k++)
                    {
                        char c3 = (char) ('a' + k);
                        Console.WriteLine("" + c1 + c2 + c3);
                    }
                }
            }
        }
    }
}
