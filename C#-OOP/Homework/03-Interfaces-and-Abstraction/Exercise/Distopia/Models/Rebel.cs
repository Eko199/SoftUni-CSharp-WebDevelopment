namespace Distopia.Models
{
    using Interfaces;

    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Food = 0;
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }

        public void BuyFood() => Food += 5;
    }
}
