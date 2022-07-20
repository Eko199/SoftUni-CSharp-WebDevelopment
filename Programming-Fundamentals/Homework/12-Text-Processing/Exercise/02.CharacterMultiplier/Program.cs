using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            int sum = 0;

            int minLength = Math.Min(strings[0].Length, strings[1].Length);
            for (int i = 0; i < minLength; i++)
            {
                sum += strings[0][i] * strings[1][i];
            }

            sum += (strings[0].Length > strings[1].Length ? strings[0] : strings[1])[minLength..].Sum(c =>  c);
            Console.WriteLine(sum);
        }
    }
}
