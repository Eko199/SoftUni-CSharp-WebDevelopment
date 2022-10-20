using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person person) 
            => people.Add(person);

        public Person GetOldestMember() 
            => people.OrderByDescending(person => person.Age).First();
    }
}
