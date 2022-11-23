namespace MilitaryElite.Models
{
    using Interfaces;

    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
            => base.ToString() + $" Salary: {Salary:F2}";
    }
}
