using System;
using System.Linq;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            Random rnd = new Random();

            for (int i = 0; i < strings.Length; i++)
            {
                int random = rnd.Next(0, strings.Length);
                (strings[random], strings[i]) = (strings[i], strings[random]);
            }

            Console.WriteLine(string.Join('\n', strings));
        }
    }
}
