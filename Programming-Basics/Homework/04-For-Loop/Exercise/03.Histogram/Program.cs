using System;

namespace Histogram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                if (a < 200)
                    num1++;
                else if (a < 400)
                    num2++;
                else if (a < 600)
                    num3++;
                else if (a < 800)
                    num4++;
                else
                    num5++;
            }
            
            int num = num1 + num2 + num3 + num4 + num5;
            double p1 = 100.0 * num1 / num;
            double p2 = 100.0 * num2 / num;
            double p3 = 100.0 * num3 / num;
            double p4 = 100.0 * num4 / num;
            double p5 = 100.0 * num5 / num;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
