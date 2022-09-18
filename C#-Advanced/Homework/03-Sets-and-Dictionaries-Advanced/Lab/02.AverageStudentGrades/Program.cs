using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (!studentGrades.ContainsKey(input[0]))
                    studentGrades[input[0]] = new List<decimal>();

                studentGrades[input[0]].Add(decimal.Parse(input[1]));
            }

            foreach (var (student, grades) in studentGrades)
            {
                Console.WriteLine($"{student} -> {string.Join(' ', grades.Select(grade => $"{grade:f2}"))} (avg: {grades.Average():f2})");
            }
        }
    }
}
