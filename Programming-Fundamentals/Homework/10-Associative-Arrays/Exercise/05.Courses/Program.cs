using System;
using System.Collections.Generic;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split(" : ");

                if (!courses.ContainsKey(tokens[0]))
                    courses.Add(tokens[0], new List<string> { tokens[1] });
                else
                    courses[tokens[0]].Add(tokens[1]);

                command = Console.ReadLine();
            }

            foreach (var (name, students) in courses)
            {
                Console.WriteLine(name + ": " + students.Count);
                students.ForEach(student => Console.WriteLine("-- " + student));
            }
        }
    }
}
