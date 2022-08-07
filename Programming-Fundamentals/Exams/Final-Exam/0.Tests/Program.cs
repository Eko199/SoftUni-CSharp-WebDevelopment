using System;
using System.Collections.Generic;

namespace _0.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string> { { "aa", "bb" } };
            dict["aa"]+= "a";
            Console.WriteLine(100f == 100d);
            string name = "George";
            //name[2] = "m";
            //Console.WriteLine(name[2]);
            //int i = int.Parse(true);
            int a = 5;
            int b = a++;
            int c = ++a;
            Console.WriteLine(c);
        }
    }
}
