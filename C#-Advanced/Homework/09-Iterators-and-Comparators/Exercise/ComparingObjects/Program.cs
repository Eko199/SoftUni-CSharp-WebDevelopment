using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] personInfo = command.Split();
                people.Add(new Person(personInfo[0], int.Parse(personInfo[1]), personInfo[2]));
            }

            Person person = people[int.Parse(Console.ReadLine()) - 1];
            int equalCount = people.Count(p => person.CompareTo(p) == 0);

            Console.WriteLine(equalCount == 1 
                ? "No matches" 
                : $"{equalCount} {people.Count - equalCount} {people.Count}");
        }
    }
}
