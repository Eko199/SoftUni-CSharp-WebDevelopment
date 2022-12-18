namespace FakeAxeAndDummy.Tests
{
    using Models.Contracts;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        private Mock<IWeapon> weapon;
        private Hero hero;

        [SetUp]
        public void SetUp()
        {
            weapon = new Mock<IWeapon>();
            hero = new Hero("Az", weapon.Object);
        }

        [TestCase("")]
        [TestCase("        ")]
        [TestCase("a")]
        [TestCase("asdf")]
        [TestCase("asdgarwegqeghrrghghrgewrgw")]
        public void Test_ConstructorShouldSetFields(string name)
        {
            hero = new Hero(name, weapon.Object);

            Assert.AreEqual(name, hero.Name);
            Assert.AreEqual(0, hero.Experience);
            Assert.AreEqual(weapon.Object, hero.Weapon);
        }

        [Test]
        public void Test_AttackShouldMakeWeaponAttack()
        {
            var target = new Mock<ITarget>();

            hero.Attack(target.Object);
            weapon.Verify(w => w.Attack(target.Object), Times.Once);
        }

        [Test]
        public void Test_AttackDeadTargetShouldGiveExp()
        {
            var target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.GiveExperience()).Returns(100);

            hero.Attack(target.Object);
            Assert.AreEqual(100, hero.Experience);
        }
    }
}