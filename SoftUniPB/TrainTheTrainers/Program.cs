using System;

namespace TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double gradeSum = 0;
            int counter = 0;

            while (presentation != "Finish")
            {
                counter++;
                double currentGradeSum = 0;

                for (int i = 0; i < n; i++)
                {
                    currentGradeSum += double.Parse(Console.ReadLine());
                }

                gradeSum += currentGradeSum;
                currentGradeSum /= n;

                Console.WriteLine($"{presentation} - {currentGradeSum:f2}.");
                presentation = Console.ReadLine();
            }

            gradeSum /= counter * n;
            Console.WriteLine($"Student's final assessment is {gradeSum:f2}.");
        }
    }
}
