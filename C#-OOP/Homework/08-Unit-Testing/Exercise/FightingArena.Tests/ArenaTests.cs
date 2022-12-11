namespace FightingArena.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private const string WarriorName = "az";
        private const int WarriorDamage = 10;
        private const int WarriorHP = 50;
        private Warrior warrior, attackedWarrior;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(WarriorName, WarriorDamage, WarriorHP);
            attackedWarrior = new Warrior("toi", 10, 35);
            arena = new Arena();
        }

        [Test]
        public void Test_ConstructorShouldSetEmptyArena()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Test_ConstructorShouldSetEmptyListInArena()
        {
            CollectionAssert.AreEqual(new List<Warrior>(), arena.Warriors);
        }

        [Test]
        public void Test_EnrollShouldIncreaseCount()
        {
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_EnrollShouldAddWarrior()
        {
            arena.Enroll(warrior);
            Assert.IsTrue(arena.Warriors.Contains(warrior));
        }

        [Test]
        public void Test_EnrollWarriorWithExistingNameShouldThrow()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Test_FightWithExistingWarriorsShouldMakeAttackerAttackDefender()
        {
            int originalAttackedHp = attackedWarrior.HP;
            arena.Enroll(warrior);
            arena.Enroll(attackedWarrior);
            arena.Fight(warrior.Name, attackedWarrior.Name);

            Assert.AreEqual(WarriorHP - attackedWarrior.Damage, warrior.HP);
            Assert.AreEqual(originalAttackedHp - warrior.Damage, attackedWarrior.HP);
        }

        [Test]
        public void Test_FightWithNotEnrolledDefenderShouldThrow()
        {
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, attackedWarrior.Name));
        }

        [Test]
        public void Test_FightWithNotEnrolledAttackerShouldThrow()
        {
            arena.Enroll(attackedWarrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, attackedWarrior.Name));
        }
    }
}
