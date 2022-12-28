namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> models;

        public RaceRepository()
        {
            models = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace race) => models.Add(race);

        public bool Remove(IRace race) => models.Remove(race);

        public IRace FindByName(string raceName) => models.FirstOrDefault(r => r.RaceName == raceName);
    }
}