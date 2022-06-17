using System;
using System.Text;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMiddleCharacters(Console.ReadLine());
        }

        private static void PrintMiddleCharacters(string text)
        {
            StringBuilder sb = new StringBuilder(text);

            while (sb.Length > 2)
            {
                sb.Remove(0, 1);
                sb.Remove(sb.Length - 1, 1);
            }

            Console.WriteLine(sb);
        }
    }
}
