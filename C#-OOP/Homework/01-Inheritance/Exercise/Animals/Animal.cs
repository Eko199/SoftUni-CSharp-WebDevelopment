using System;

namespace Animals
{
    public class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid input!");
                age = value;
            }
        }

        public virtual string Gender { get; set; }

        public virtual string ProduceSound() => string.Empty;

        public override string ToString()
            => $"{GetType().Name}\n{Name} {Age} {Gender}\n{ProduceSound()}";
    }
}
