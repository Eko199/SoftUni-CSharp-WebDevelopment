namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly HashSet<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            repairs = new HashSet<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => repairs;

        public void AddRepair(IRepair repair) => repairs.Add(repair);

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine();
            sb.AppendLine("Repairs:");

            foreach (var repair in repairs)
            {
                sb.AppendLine('\t' + repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
