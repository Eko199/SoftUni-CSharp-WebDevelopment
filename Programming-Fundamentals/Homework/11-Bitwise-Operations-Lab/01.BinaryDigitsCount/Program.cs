using System;
using System.Linq;
using System.Text;

namespace _01.BinaryDigitsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            byte b = byte.Parse(Console.ReadLine());

            int count = 0;
            while (number > 0)
            {
                if ((number & 1) == b) count++;
                number >>= 1;
            }

            Console.WriteLine(count);
        }
    }
}
