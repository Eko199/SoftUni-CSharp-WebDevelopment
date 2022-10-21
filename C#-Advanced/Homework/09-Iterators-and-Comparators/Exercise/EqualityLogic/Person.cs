using System;

namespace EqualityLogic
{
    internal class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int result = name.CompareTo(other.name);
            if (result != 0) return result;

            return age.CompareTo(other.age);
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null) 
                return false;

            return other.name == name && other.age == age;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + age.GetHashCode();
        }
    }
}
