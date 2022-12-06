using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class AxeTests
    {
        private int attackPoints = 10;
        private int durabilityPoints = 10;
        private Axe axe;
        private int dummyHealth = 100;
        private int dummyExp = 100;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(dummyHealth, dummyExp);
        }

        [Test]
        public void Test_AxeConstructorShouldSetAttackAndDurability()
        {
            Assert.AreEqual(attackPoints, axe.AttackPoints, "Incorrect attackPoints set up.");
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints, "Incorrect durabilityPoints set up.");
        }

        [Test]
        public void Tes_AxeShouldLose1DurabilityAfterEachAttack()
        {
            const int attacks = 5;
            AttackDummy(attacks);

            Assert.AreEqual(durabilityPoints - attacks, axe.DurabilityPoints, "Axe did not lose correct points of durability.");
        }

        [Test]
        public void Test_AxeShouldBreakWhenDurabilityGoesBelow0()
        {
            const int attacks = 11;

            Assert.Throws<InvalidOperationException>(() =>
            {
                AttackDummy(attacks);
            }, "Axe did not break as expected.");
        }

        [Test]
        public void Test_AttackingWithBrokenAxeShouldThrow()
        {
            axe = new Axe(attackPoints, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }, "Broken axe should not be able to attack.");
        }

        private void AttackDummy(int attacks)
        {
            for (int i = 0; i < attacks; i++)
            {
                axe.Attack(dummy);
            }
        }
    }
}