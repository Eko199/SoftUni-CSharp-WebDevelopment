using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (value.Length < 3)
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");

                lastName = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Age cannot be zero or a negative integer!");

                age = value;
            }
        }

        public decimal Salary
        {
            get => salary;
            private set
            {
                if (value < 460)
                    throw new ArgumentException("Salary cannot be less than 460 leva!");

                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage) 
            => Salary *= 1 + (Age >= 30 ? 1 : 0.5M) * percentage / 100;

        public override string ToString()
            => $"{FirstName} {LastName} receives {Salary:F2} leva.";
    }
}
