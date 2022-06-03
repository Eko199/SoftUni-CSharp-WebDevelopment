using System;

namespace _10.Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //poke power
            int m = int.Parse(Console.ReadLine()); //distance
            int y = int.Parse(Console.ReadLine()); //exhaustion factor

            int originalN = n;
            int count = 0;
            while (n >= m)
            {
                n -= m;
                count++;

                if (n == originalN / 2.0 && y != 0)
                    n /= y;
            }

            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}
