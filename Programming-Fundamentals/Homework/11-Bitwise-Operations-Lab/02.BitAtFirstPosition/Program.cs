using System;

namespace _02.BitAtFirstPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((int.Parse(Console.ReadLine()) >> 1) & 1);
        }
    }
}
