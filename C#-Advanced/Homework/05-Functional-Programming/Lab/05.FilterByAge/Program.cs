using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    internal class Program
    {
        internal class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();
            Func<Person, bool> filter = CreateFilter(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Action<Person> printer = CreatePrinter(Console.ReadLine());
            PrintFilteredPeople(people, filter, printer);
        }

        private static List<Person> ReadPeople()
        {
            int count = int.Parse(Console.ReadLine());
            var people = new List<Person>(count);

            for (int i = 0; i < count; i++)
            {
                string[] person = Console.ReadLine().Split(", ");

                people.Add(new Person
                {
                    Name = person[0],
                    Age = int.Parse(person[1])
                });
            }

            return people;
        }

        private static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
            => person => condition switch
            {
                "younger" => person.Age < ageThreshold,
                "older" => person.Age >= ageThreshold,
                _ => throw new ArgumentException()
            };

        private static Action<Person> CreatePrinter(string format)
            => format switch
            {
                "name" => person => Console.WriteLine(person.Name),
                "age" => person => Console.WriteLine(person.Age),
                "name age" => person => Console.WriteLine($"{person.Name} - {person.Age}"),
                _ => throw new ArgumentException()
            };

        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
            => people.Where(filter).ToList().ForEach(printer);
    }
}
