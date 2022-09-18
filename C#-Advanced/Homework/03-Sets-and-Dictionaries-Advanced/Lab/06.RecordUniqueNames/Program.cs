using System;
using System.Collections.Generic;

namespace _06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var namesSet = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                namesSet.Add(Console.ReadLine());
            }

            foreach (string name in namesSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
