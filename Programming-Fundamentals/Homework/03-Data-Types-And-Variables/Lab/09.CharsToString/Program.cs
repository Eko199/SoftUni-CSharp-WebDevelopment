using System;

namespace _09.CharsToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c1 = char.Parse(Console.ReadLine());
            char c2 = char.Parse(Console.ReadLine());
            char c3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{c1}{c2}{c3}");
        }
    }
}
