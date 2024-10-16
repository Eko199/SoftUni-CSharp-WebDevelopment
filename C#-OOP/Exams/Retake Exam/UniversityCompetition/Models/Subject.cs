﻿namespace UniversityCompetition.Models
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Subject : ISubject
    {
        private string name;

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;
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

        public double Rate { get; }
    }
}