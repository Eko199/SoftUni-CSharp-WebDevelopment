using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        private int dummyHealth = 100;
        private int dummyExp = 100;
        private Dummy dummy, deadDummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(dummyHealth, dummyExp);
            deadDummy = new Dummy(0, dummyExp);
        }

        [Test]
        public void Test_DummyConstructorShouldSetHealthAndExperience()
        {
            Assert.AreEqual(dummyHealth, dummy.Health, "Incorrect dummy health set up.");
        }

        [Test]
        public void Test_DummyShouldTakeCorrectDamage()
        {
            const int damage = 20;
            dummy.TakeAttack(damage);

            Assert.AreEqual(dummyHealth - damage, dummy.Health, "Dummy did not take correct amount of damage.");
        }

        [Test]
        public void Test_DeadDummyTakingAttackThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(20);
            }, "Dead dummy should not take damage!");
        }

        [Test]
        public void Test_DummyShouldNotGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            }, "Alive dummy should not give experience!");
        }

        [Test]
        public void Test_DeadDummyShouldGiveExperience()
        {
            Assert.AreEqual(dummyExp, deadDummy.GiveExperience(), "Dead dummy does not give correct amount of experience.");
        }

        [Test]
        public void Test_DummyShouldNotBeDead()
        {
            Assert.IsFalse(dummy.IsDead(), "Alive dummy is dead.");
        }

        [Test]
        public void Test_DeadDummyShouldBeDead()
        {
            Assert.IsTrue(deadDummy.IsDead(), "Dead dummy is not dead.");
        }
    }
}