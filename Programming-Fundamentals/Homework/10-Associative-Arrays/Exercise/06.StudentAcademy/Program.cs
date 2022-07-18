using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                    students[name] = new List<double> { grade };
                else
                    students[name].Add(grade);
            }

            Dictionary<string, double> studentsAverage = students
                .Where(student => student.Value.Average() >= 4.5)
                .ToDictionary(student => student.Key, student => student.Value.Average());

            foreach (var student in studentsAverage)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
