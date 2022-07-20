using System;
using System.Linq;

namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(input.Where(char.IsDigit).ToArray());
            Console.WriteLine(input.Where(char.IsLetter).ToArray());
            Console.WriteLine(input.Where(c => !char.IsLetterOrDigit(c)).ToArray());
        }
    }
}
