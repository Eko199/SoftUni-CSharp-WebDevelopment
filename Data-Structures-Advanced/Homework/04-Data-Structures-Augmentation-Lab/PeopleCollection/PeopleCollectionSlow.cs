namespace CollectionOfPeople
{
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleCollectionSlow : IPeopleCollection
    {
        private readonly IList<Person> people = new List<Person>();

        public int Count => people.Count;

        public bool Add(string email, string name, int age, string town)
        {
            if (Find(email) != null)
            {
                return false;
            }

            people.Add(new Person(email, name, age, town));
            return true;
        }

        public bool Delete(string email) => people.Remove(Find(email));

        public Person Find(string email) => people.SingleOrDefault(p => p.Email == email);

        public IEnumerable<Person> FindPeople(string emailDomain)
            => people.Where(p => p.Email.EndsWith($"@{emailDomain}"))
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(string name, string town)
            => people.Where(p => p.Name == name && p.Town == town)
                .OrderBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge)
            => people.Where(p => p.Age >= startAge && p.Age <= endAge)
                .OrderBy(p => p.Age)
                .ThenBy(p => p.Email);

        public IEnumerable<Person> FindPeople(int startAge, int endAge, string town)
            => FindPeople(startAge, endAge)
                .Where(p => p.Town == town)
                .OrderBy(p => p.Age)
                .ThenByDescending(p => p.Town)
                .ThenBy(p => p.Email);
    }
}
