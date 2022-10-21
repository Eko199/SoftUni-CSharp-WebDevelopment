using System;
using System.Linq;

namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split().ToArray();
            var personAddress = new Threeuple<string, string, string>(info[0] + " " + info[1], info[2], info[3]);

            info = Console.ReadLine().Split().ToArray();
            var personBeer = new Threeuple<string, int, bool>(info[0], int.Parse(info[1]), info[2] == "drunk");

            info = Console.ReadLine().Split().ToArray();
            var nameBank = new Threeuple<string, double, string>(info[0], double.Parse(info[1]), info[2]);

            Console.WriteLine(personAddress);
            Console.WriteLine(personBeer);
            Console.WriteLine(nameBank);
        }
    }
}
