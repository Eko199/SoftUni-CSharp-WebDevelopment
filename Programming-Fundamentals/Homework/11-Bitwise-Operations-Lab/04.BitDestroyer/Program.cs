using System;

namespace _04.BitDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int mask = ~(1 << p);
            Console.WriteLine(number & mask);
        }
    }
}
