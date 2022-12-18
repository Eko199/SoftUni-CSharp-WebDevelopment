namespace FakeAxeAndDummy.Models.Contracts
{
    public interface ITarget
    {

        public int Health { get; }

        void TakeAttack(int attackPoints);
        int GiveExperience();
        bool IsDead();
    }
}