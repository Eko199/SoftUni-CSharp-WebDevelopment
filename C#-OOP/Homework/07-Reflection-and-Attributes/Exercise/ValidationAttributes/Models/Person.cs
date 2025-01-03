﻿namespace ValidationAttributes.Models
{
    using Utilities.Attributes;

    public class Person
    {
        private const int MinAge = 12, MaxAge = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}