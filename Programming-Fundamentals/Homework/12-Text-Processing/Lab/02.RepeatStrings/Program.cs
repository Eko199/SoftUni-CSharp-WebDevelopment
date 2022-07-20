using System;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            foreach (string word in arr)
            {
                foreach (char c in word)
                    Console.Write(word);
            }
        }
    }
}
