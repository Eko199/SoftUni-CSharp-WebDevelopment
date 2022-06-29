using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        internal class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public Student(string firstName, string lastName, int age, string city)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
                City = city;
            }

            public new string ToString() => $"{FirstName} {LastName} is {Age} years old.";
        }

        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] studentInfo = input.Split();

                Student currStudent = list.Find(student =>
                    student.FirstName == studentInfo[0] && student.LastName == studentInfo[1]);
                if (currStudent != null)
                {
                    currStudent.Age = int.Parse(studentInfo[2]);
                    currStudent.City = studentInfo[3];
                }
                else
                    list.Add(new Student(studentInfo[0], studentInfo[1], int.Parse(studentInfo[2]), studentInfo[3]));

                input = Console.ReadLine();
            }

            string city = Console.ReadLine(); 
            list.Where(student => student.City.Equals(city)).ToList().ForEach(student => Console.WriteLine(student.ToString()));
        }
    }
}
