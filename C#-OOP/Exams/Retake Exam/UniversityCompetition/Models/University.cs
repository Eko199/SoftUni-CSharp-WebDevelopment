namespace UniversityCompetition.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class University : IUniversity
    {
        private static readonly ISet<string> AvailableCategories = new HashSet<string> { "Technical", "Economical", "Humanity" };

        private readonly ICollection<int> requiredSubjects;
        private string name;
        private string category;
        private int capacity;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects;
        }

        public int Id { get; }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                name = value;
            }
        }

        public string Category
        {
            get => category;
            private set
            {
                if (!AvailableCategories.Contains(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                
                category = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => (IReadOnlyCollection<int>)requiredSubjects;
    }
}