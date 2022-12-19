namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class SubjectRepository : IRepository<ISubject>
    {
        private readonly ICollection<ISubject> models;

        public SubjectRepository()
        {
            models = new HashSet<ISubject>();
        }

        public IReadOnlyCollection<ISubject> Models => (IReadOnlyCollection<ISubject>)models;

        public void AddModel(ISubject subject) => models.Add(subject);

        public ISubject FindById(int id) => models.SingleOrDefault(s => s.Id == id);

        public ISubject FindByName(string name) => models.FirstOrDefault(s => s.Name == name);
    }
}