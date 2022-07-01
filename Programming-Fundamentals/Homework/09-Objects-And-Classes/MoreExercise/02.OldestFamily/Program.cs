using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamily
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString() => Name + " " + Age;
    }

    class Family
    {
        public List<Person> people { get; set; } = new List<Person>();

        public void AddMember(Person person) => people.Add(person);

        public Person GetOldestMember() => people.OrderByDescending(person => person.Age).ToArray()[0];
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                family.AddMember(new Person(personInfo[0], int.Parse(personInfo[1])));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
