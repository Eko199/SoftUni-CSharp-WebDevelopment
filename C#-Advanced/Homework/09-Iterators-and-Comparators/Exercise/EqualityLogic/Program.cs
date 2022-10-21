using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();
                Person person = new Person(personInfo[0], int.Parse(personInfo[1]));

                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
