namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly HashSet<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            privates = new HashSet<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => privates;

        public void AddPrivate(IPrivate iPrivate) => privates.Add(iPrivate);

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());
            sb.AppendLine();
            sb.AppendLine("Privates:");

            foreach (var iPrivate in privates)
            {
                sb.AppendLine('\t' + iPrivate.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
