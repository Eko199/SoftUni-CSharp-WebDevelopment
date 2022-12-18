namespace FakeAxeAndDummy.Models.Contracts
{
    public interface IWeapon
    {
        public int AttackPoints { get; }
        public int DurabilityPoints { get; }

        public void Attack(ITarget target);
    }
}