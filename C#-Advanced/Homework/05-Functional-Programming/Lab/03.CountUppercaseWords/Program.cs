using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isCapitalized = word => char.IsUpper(word[0]);

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(isCapitalized)));
        }
    }
}
