using System;

namespace NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            bool end = false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write($"{current} ");
                    if (current == n)
                    {
                        end = true;
                        break;
                    }
                    current++;
                }
                if (end)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
