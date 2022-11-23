namespace MilitaryElite.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
