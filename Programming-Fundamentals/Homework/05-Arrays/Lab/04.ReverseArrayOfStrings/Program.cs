using System;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArr = Console.ReadLine().Split();
            Array.Reverse(stringArr);
            Console.WriteLine(string.Join(' ', stringArr));
        }
    }
}
