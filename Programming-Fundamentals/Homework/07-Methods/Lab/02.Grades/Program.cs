using System;

namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintGrade(double.Parse(Console.ReadLine()));
        }

        static void PrintGrade(double grade)
        {
            switch (grade)
            {
                case double m when m >= 2 && m <= 2.99:
                    Console.WriteLine("Fail");
                    break;
                case double m when m >= 3 && m <= 3.49:
                    Console.WriteLine("Poor");
                    break;
                case double m when m >= 3.5 && m <= 4.49:
                    Console.WriteLine("Good");
                    break;
                case double m when m >= 4.5 && m <= 5.49:
                    Console.WriteLine("Very good");
                    break;
                case double m when m >= 5.5 && m <= 6:
                    Console.WriteLine("Excellent");
                    break;
            }
        }
    }
}
