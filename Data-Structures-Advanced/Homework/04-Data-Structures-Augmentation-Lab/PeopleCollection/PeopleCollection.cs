namespace CollectionOfPeople
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PeopleCollection : IPeopleCollection
    {
        private readonly IDictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
        private readonly IDictionary<string, SortedSet<Person>> peopleByEmaiDomain = new Dictionary<string, SortedSet<Person>>();

        private readonly IDictionary<(string name, string town), SortedSet<Person>> peopleByNameAndTown =
            new Dictionary<(string, string), SortedSet<Person>>();

        private readonly OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();

        private readonly IDictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByTownAndAge =
            new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

        public int Count => peopleByEmail.Count;

        public bool Add(string email, string name, int age, string town)
        {
            if (Find(email) != null)
                return false;

            var person = new Person(email, name, age, town);

            peopleByEmail.Add(email, person);
            peopleByEmaiDomain.AppendValueToKey(email.Split('@')[1], person);
            peopleByNameAndTown.AppendValueToKey((name, town), person);
            peopleByAge.AppendValueToKey(age, person);

            peopleByTownAndAge.EnsureKeyExists(town);
            peopleByTownAndAge[town].AppendValueToKey(age, person);

            return true;
        }

        public bool Delete(string email)
        {
            var person = Find(email);

            if (person == null)
            {
                return false;
            }

            peopleByEmaiDomain[email.Split('@')[1]].Remove(person);
            peopleByNameAndTown[(person.Name, person.Town)].Remove(person);
            peopleByAge[person.Age].Remove(person);
            peopleByTownAndAge[person.Town][person.Age].Remove(person);

            return peopleByEmail.Remove(email);
        }

        public Person Find(string email) => !peopleByEmail.ContainsKey(email) ? null : peopleByEmail[email];

        public IEnumerable<Person> FindPeople(string emailDomain) => peopleByEmaiDomain.GetValuesForKey(emailDomain);

        public IEnumerable<Person> FindPeople(string name, string town) => peopleByNameAndTown.GetValuesForKey((name, town));

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => peopleByAge.Range(startAge, true, endAge, true)
                .SelectMany(agePeople => agePeople.Value)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
        {
            if (!peopleByTownAndAge.ContainsKey(town))
            {
                return Enumerable.Empty<Person>();
            }

            return peopleByTownAndAge[town].Range(startAge, true, endAge, true)
                .SelectMany(agePeople => agePeople.Value);
        }
    }
}
