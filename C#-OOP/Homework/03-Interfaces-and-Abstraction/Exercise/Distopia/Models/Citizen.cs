namespace Distopia.Models
{
    using Interfaces;

    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id)
        {
            Food = 0;
            Name = name;
            Age = age;
            Id = id;
        }

        public Citizen(string name, int age, string id, string birthdate) : this(name, age, id)
        {
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
        public int Food { get; private set; }

        public void BuyFood() => Food += 10;
    }
}
