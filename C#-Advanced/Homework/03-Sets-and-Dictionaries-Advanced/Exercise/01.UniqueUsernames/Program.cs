using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var usernamesSet = new HashSet<string>(count);

            for (int i = 0; i < count; i++)
            {
                usernamesSet.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernamesSet));
        }
    }
}
