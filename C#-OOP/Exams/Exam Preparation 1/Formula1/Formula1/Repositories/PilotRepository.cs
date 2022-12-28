namespace Formula1.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => models.AsReadOnly();

        public void Add(IPilot pilot) => models.Add(pilot);

        public bool Remove(IPilot pilot) => models.Remove(pilot);

        public IPilot FindByName(string fullName) => models.FirstOrDefault(p => p.FullName == fullName);
    }
}