using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> articles = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                articles.Add(new Student(studentInfo[0], studentInfo[1], float.Parse(studentInfo[2])));
            }

            Console.WriteLine(string.Join(Environment.NewLine, articles.OrderByDescending(student => student.Grade)));
        }
    }
}
