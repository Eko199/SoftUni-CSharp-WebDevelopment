using System;

namespace AreaOfFigure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();
            double area = 0;
            double a = double.Parse(Console.ReadLine());

            if (shape == "square")
            {
                area = a * a;
            }
            else if (shape == "rectangle")
            {
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (shape == "circle")
            {
                area = a * a * Math.PI;
            }
            else if (shape == "triangle")
            {
                double ha = double.Parse(Console.ReadLine());
                area = a * ha / 2;
            }

            Console.WriteLine($"{area:F3}");
        }
    }
}
