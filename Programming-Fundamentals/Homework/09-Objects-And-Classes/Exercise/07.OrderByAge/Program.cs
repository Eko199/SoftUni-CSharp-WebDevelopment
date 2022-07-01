using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public override string ToString() => $"{Name} with ID: {ID} is {Age} years old.";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (people.Exists(person => person.ID == input[1]))
                {
                    Person currentPerson = people.Find(person => person.ID == input[1]);
                    currentPerson.Name = input[0];
                    currentPerson.Age = int.Parse(input[2]);
                }
                else
                    people.Add(new Person(input[0], input[1], int.Parse(input[2])));

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(Environment.NewLine, people.OrderBy(person => person.Age)));
        }
    }
}
