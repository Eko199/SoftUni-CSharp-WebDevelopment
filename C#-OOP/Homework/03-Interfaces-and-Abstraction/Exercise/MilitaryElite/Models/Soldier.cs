namespace MilitaryElite.Models
{
    using Interfaces;

    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString()
            => $"Name: {FirstName} {LastName} Id: {Id}";
    }
}
