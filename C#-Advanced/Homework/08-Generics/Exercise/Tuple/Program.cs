using System;
using System.Linq;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split().ToArray();
            Tuple<string, string> personAddress = new Tuple<string, string>(info[0] + " " + info[1], info[2]);

            info = Console.ReadLine().Split().ToArray();
            Tuple<string, int> personBeer = new Tuple<string, int>(info[0], int.Parse(info[1]));

            info = Console.ReadLine().Split().ToArray();
            Tuple<int, double> intDouble = new Tuple<int, double>(int.Parse(info[0]), double.Parse(info[1]));

            Console.WriteLine(personAddress);
            Console.WriteLine(personBeer);
            Console.WriteLine(intDouble);
        }
    }
}
