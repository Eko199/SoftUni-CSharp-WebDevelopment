using System;

namespace _03.P_thBit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine((int.Parse(Console.ReadLine()) >> int.Parse(Console.ReadLine())) & 1);
        }
    }
}
