using System;
using System.Linq;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", new Lake(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())));
        }
    }
}
