namespace NavalVessels.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Contracts;

    public class VesselRepository : IRepository<IVessel>
    {
        private readonly ICollection<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new HashSet<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => (IReadOnlyCollection<IVessel>)vessels;

        public void Add(IVessel vessel) => vessels.Add(vessel);

        public bool Remove(IVessel vessel) => vessels.Remove(vessel);

        public IVessel FindByName(string name) => vessels.SingleOrDefault(v => v.Name == name);
    }
}