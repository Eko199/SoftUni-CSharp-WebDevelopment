using System;

namespace _06.Tri_BitSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int mask = 7 << p;
            Console.WriteLine(number ^ mask);
        }
    }
}
