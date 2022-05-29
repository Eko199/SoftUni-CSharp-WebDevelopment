using System;

namespace _01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double z = double.Parse(Console.ReadLine());

            if (x < y) swap(ref x, ref y);
            if (y < z) swap(ref y, ref z);
            if (x < y) swap(ref x, ref y);

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }

        static void swap(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }
    }
}
