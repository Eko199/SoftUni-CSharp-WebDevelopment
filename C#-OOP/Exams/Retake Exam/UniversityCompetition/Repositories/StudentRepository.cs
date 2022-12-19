namespace UniversityCompetition.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class StudentRepository : IRepository<IStudent>
    {
        private readonly ICollection<IStudent> models;

        public StudentRepository()
        {
            models = new HashSet<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models => (IReadOnlyCollection<IStudent>) models;

        public void AddModel(IStudent student) => models.Add(student);

        public IStudent FindById(int id) => models.SingleOrDefault(s => s.Id == id);

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return models.FirstOrDefault(s => s.FirstName == names[0] && s.LastName == names[1]);
        }
    }
}