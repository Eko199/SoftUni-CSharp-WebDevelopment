using System;

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double sum = 0;

            for (int i = 0; i < 12; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade < 4)
                {
                    counter++;
                    if (counter >= 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {i+2-counter} grade");
                        break;
                    }
                }
                sum += grade;
            }

            if (counter < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {sum /= 12+counter:f2}");
            }
        }
    }
}
