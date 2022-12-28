using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    using System;

    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void StartUp()
        {
            smartphone = new Smartphone("asdf", 100);
            shop = new Shop(3);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(1000000)]
        public void Test_ConstructorShouldSetFields(int capacity)
        {
            shop = new Shop(capacity);

            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }
        
        [TestCase(-1)]
        [TestCase(-1000000)]
        public void Test_ConstructorWithInvalidCapacityShouldThrow(int capacity)
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(capacity));
        }

        [Test]
        public void Test_AddShouldIncreaseCount()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddExistingPhoneShouldThrow()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone(smartphone.ModelName, 69)));
        }

        [Test]
        public void Test_AddWhenFullShouldThrow()
        {
            shop = new Shop(0);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void Test_RemoveShouldDecreaseCount()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_RemoveNotExistingPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("wergwerfg"));
        }

        [TestCase(0)]
        [TestCase(50)]
        [TestCase(100)]
        public void Test_TestPhoneShouldDecreaseBattery(int batteryUsage)
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, batteryUsage);

            Assert.AreEqual(smartphone.MaximumBatteryCharge - batteryUsage, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestNotExistingPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("asdfasdf", 34));
        }

        [Test]
        public void Test_TestPhoneWithMoreBatteryThanMaxShouldThrow()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(smartphone.ModelName, smartphone.MaximumBatteryCharge + 1));
        }

        [Test]
        public void Test_ChargePhoneShouldSetBatteryToMax()
        {
            shop.Add(smartphone);
            shop.TestPhone(smartphone.ModelName, smartphone.CurrentBateryCharge);
            shop.ChargePhone(smartphone.ModelName);

            Assert.AreEqual(smartphone.MaximumBatteryCharge, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargeNotExistingPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("werg"));
        }
    }
}