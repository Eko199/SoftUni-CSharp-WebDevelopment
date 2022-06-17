using System;
using System.Linq;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintVowelsCount(Console.ReadLine());
        }

        private static void PrintVowelsCount(string text)
        {
            Console.WriteLine(text.Count(letter => "aoueiAOUEI".Contains(letter)));
        }
    }
}
