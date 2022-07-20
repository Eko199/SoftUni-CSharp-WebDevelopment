using System;
using System.Linq;

namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            string input = Console.ReadLine();
            while (input != "find")
            {
                int i = 0;
                string decrypted = new string(input.Select(c => (char)(c - keys[i++ % keys.Length])).ToArray());

                Console.WriteLine($"Found {FindBetweenChars(decrypted, '&', '&')} at {FindBetweenChars(decrypted, '<', '>')}");
                
                input = Console.ReadLine();
            }
        }

        private static string FindBetweenChars(string str, char c1, char c2) 
            => str.Substring(str.IndexOf(c1) + 1, str.LastIndexOf(c2) - str.IndexOf(c1) - 1);
    }
}
