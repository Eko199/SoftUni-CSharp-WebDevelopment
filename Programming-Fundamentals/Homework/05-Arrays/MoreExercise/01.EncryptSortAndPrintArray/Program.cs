using System;
using System.Linq;

namespace _01.EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            int[] encryption = new int[length];
            char[] vowels = {'a', 'o', 'u', 'e', 'i', 'A', 'O', 'U', 'E', 'I'};
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                foreach (char letter in input)
                {
                    if (vowels.Contains(letter))
                        encryption[i] += letter * input.Length;
                    else
                        encryption[i] += letter / input.Length;
                }
            }

            Array.Sort(encryption);
            Console.WriteLine(string.Join('\n', encryption));
        }
    }
}
