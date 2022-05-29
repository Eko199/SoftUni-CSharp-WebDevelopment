using System;

namespace _01.Ages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            switch (age)
            {
                case int n when n >= 0 && n <= 2:
                    Console.WriteLine("baby");
                    break;
                case int n when n >= 3 && n <= 13:
                    Console.WriteLine("child");
                    break;
                case int n when n >= 14 && n <= 19:
                    Console.WriteLine("teenager");
                    break;
                case int n when n >= 20 && n <= 65:
                    Console.WriteLine("adult");
                    break;
                case int n when n >= 66:
                    Console.WriteLine("elder");
                    break;
            }
        }
    }
}
