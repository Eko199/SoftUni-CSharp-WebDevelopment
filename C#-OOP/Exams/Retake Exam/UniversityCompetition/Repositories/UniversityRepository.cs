namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class UniversityRepository : IRepository<IUniversity>
    {
        private readonly ICollection<IUniversity> models;

        public UniversityRepository()
        {
            models = new HashSet<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => (IReadOnlyCollection<IUniversity>)models;

        public void AddModel(IUniversity university) => models.Add(university);

        public IUniversity FindById(int id) => models.SingleOrDefault(u => u.Id == id);

        public IUniversity FindByName(string name) => models.FirstOrDefault(u => u.Name == name);
    }
}