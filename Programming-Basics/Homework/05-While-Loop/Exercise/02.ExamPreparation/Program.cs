using System;

namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxFailures = int.Parse(Console.ReadLine());
            int failures = 0;
            string input = Console.ReadLine();
            string lastName = "";
            double sumGrade = 0;
            int numProblems = 0;

            while (input != "Enough")
            {
                lastName = input;
                int grade = int.Parse(Console.ReadLine());
                numProblems++;
                sumGrade += grade;
                if (grade <= 4)
                {
                    failures++;
                    if (failures >= maxFailures)
                    {
                        Console.WriteLine($"You need a break, {failures} poor grades.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }

            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {sumGrade / numProblems:f2}");
                Console.WriteLine($"Number of problems: {numProblems}");
                Console.WriteLine($"Last problem: {lastName}");
            }
        }
    }
}
