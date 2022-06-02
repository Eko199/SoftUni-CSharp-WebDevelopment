using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine(Char.IsLower(c) ? "lower-case" : "upper-case");
        }
    }
}
