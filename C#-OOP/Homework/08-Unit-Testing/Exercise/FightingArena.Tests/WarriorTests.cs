namespace FightingArena.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private const string WarriorName = "az";
        private const int WarriorDamage = 10;
        private const int WarriorHP = 50;
        private Warrior warrior, attackedWarrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(WarriorName, WarriorDamage, WarriorHP);
            attackedWarrior = new Warrior("toi", 10, 35);
        }

        [TestCase("az", 1, 10)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, 10)]
        [TestCase("az", 999999999, 10)]
        [TestCase("az", 1, 0)]
        [TestCase("az", 1, 9999999)]
        public void Test_ConstructorShouldSetFields(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null, 1, 10)]
        [TestCase("", 1, 10)]
        [TestCase("        ", 1, 10)]
        [TestCase("az", 0, 10)]
        [TestCase("az", -100, 10)]
        [TestCase("az", 1, -1)]
        [TestCase("az", 1, -100)]
        public void Test_ConstructorWithInvalidArgumentsShouldThrow(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, damage, hp));
        }

        [Test]
        public void Test_NameGetterShouldReturnName()
        {
            Assert.AreEqual(typeof(Warrior).GetField("name", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(warrior), warrior.Name);
        }

        [Test]
        public void Test_DamageGetterShouldReturnDamage()
        {
            Assert.AreEqual(typeof(Warrior).GetField("damage", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(warrior), warrior.Damage);
        }

        [Test]
        public void Test_HPGetterShouldReturnHP()
        {
            Assert.AreEqual(typeof(Warrior).GetField("hp", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(warrior), warrior.HP);
        }

        [Test]
        public void Test_AttackShouldDecreaseYourHp()
        {
            warrior.Attack(attackedWarrior);
            Assert.AreEqual(WarriorHP - attackedWarrior.Damage, warrior.HP);
        }

        [Test]
        public void Test_AttackShouldDecreaseEnemyHp()
        {
            int originalAttackedHp = attackedWarrior.HP;
            warrior.Attack(attackedWarrior);

            Assert.AreEqual(originalAttackedHp - warrior.Damage, attackedWarrior.HP);
        }

        [Test]
        public void Test_AttackShouldNotDecreaseEnemyHpBeyond0()
        {
            warrior = new Warrior(WarriorName, attackedWarrior.HP + 150, WarriorHP);
            warrior.Attack(attackedWarrior);

            Assert.AreEqual(0, attackedWarrior.HP);
        }

        [Test]
        public void Test_AttackWhenBelowMinHpShouldThrow()
        {
            warrior = new Warrior(WarriorName, WarriorDamage, 1);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }

        [Test]
        public void Test_AttackWhenEnemyBelowMinHpShouldThrow()
        {
            attackedWarrior = new Warrior(WarriorName, WarriorDamage, 1);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }

        [Test]
        public void Test_AttackStrongerEnemyShouldThrow()
        {
            attackedWarrior = new Warrior(WarriorName, WarriorHP * 2, WarriorHP);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(attackedWarrior));
        }
    }
}