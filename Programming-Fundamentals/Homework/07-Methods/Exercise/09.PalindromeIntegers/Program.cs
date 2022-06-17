using System;
using System.Text;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Console.WriteLine(IsPalindrome(input));
                input = Console.ReadLine();
            }
        }

        private static bool IsPalindrome(string input)
        {
            StringBuilder stringBuilder = new StringBuilder(input);

            while (stringBuilder.Length > 1)
            {
                if (stringBuilder[0] != stringBuilder[^1])
                    return false;

                stringBuilder.Remove(0, 1);
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            return true;
        }
    }
}
