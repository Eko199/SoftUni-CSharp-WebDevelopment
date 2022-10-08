using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addVAT = price => (price * 1.2).ToString("F2");

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)));
        }
    }
}
