using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                people.Add(new Person(personInfo[0], int.Parse(personInfo[1])));
            }

            Console.WriteLine(string.Join(Environment.NewLine, people
                .Where(person => person.Age > 30)
                .OrderBy(person => person.Name)
                .Select(person => $"{person.Name} - {person.Age}")));
        }
    }
}
