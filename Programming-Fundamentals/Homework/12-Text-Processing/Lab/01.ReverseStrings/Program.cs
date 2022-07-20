using System;
using System.Linq;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                Console.WriteLine($"{input} = {new string(input.Reverse().ToArray())}");
                input = Console.ReadLine();
            }
        }
    }
}
