namespace MilitaryElite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Enums;
    using Interfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly HashSet<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new HashSet<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => missions;

        public void AddMission(IMission mission) => missions.Add(mission);

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine();
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine('\t' + mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}


