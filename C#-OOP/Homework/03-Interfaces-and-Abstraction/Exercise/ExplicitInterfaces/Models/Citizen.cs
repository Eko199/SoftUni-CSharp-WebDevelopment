﻿namespace ExplicitInterfaces.Models
{
    using Interfaces;

    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; }
        public int Age { get; }
        public string Country { get; }

        string IResident.GetName() => "Mr/Ms/Mrs " + Name;

        string IPerson.GetName() => Name;
    }
}
