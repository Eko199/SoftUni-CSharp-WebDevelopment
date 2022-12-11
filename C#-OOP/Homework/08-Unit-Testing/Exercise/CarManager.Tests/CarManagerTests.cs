namespace CarManager.Tests
{
    using System;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string carMake = "a", carModel = "b";
        private double carFuelConsumption = 1.5, carFuelCapacity = 11.1;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car(carMake, carModel, carFuelConsumption, carFuelCapacity);
        }

        [TestCase("a", "b", 1.5, 3.3)]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "b", 1.5, 3.3)]
        [TestCase("a", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", 1.5, 3.3)]
        [TestCase("a", "b", 0.01, 3.3)]
        [TestCase("a", "b", 99999999, 3.3)]
        [TestCase("a", "b", 1.5, 0.01)]
        [TestCase("a", "b", 1.5, 9999999999)]
        public void Test_ConstructorShouldSetFields(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }


        [TestCase("", "b", 1.5, 3.3)]
        [TestCase(null, "b", 1.5, 3.3)]
        [TestCase("a", "", 1.5, 3.3)]
        [TestCase("a", null, 1.5, 3.3)]
        [TestCase("a", "b", 0, 3.3)]
        [TestCase("a", "b", -1000000.9, 3.3)]
        [TestCase("a", "b", 1.5, 0)]
        [TestCase("a", "b", 1.5, -1000000.9)]
        public void Test_ConstructorWithIncorrectDataShouldThrow(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Test_MakeGetterShouldGetMake()
        {
            Assert.AreEqual(typeof(Car).GetField("make", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(car), car.Make);
        }

        [Test]
        public void Test_ModelGetterShouldGetModel()
        {
            Assert.AreEqual(typeof(Car).GetField("model", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(car), car.Model);
        }

        [Test]
        public void Test_FuelConsumptionGetterShouldGetFuelConsumption()
        {
            Assert.AreEqual(typeof(Car).GetField("fuelConsumption", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(car), car.FuelConsumption);
        }

        [Test]
        public void Test_FuelCapacityGetterShouldGetFuelCapacity()
        {
            Assert.AreEqual(typeof(Car).GetField("fuelCapacity", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(car), car.FuelCapacity);
        }

        [Test]
        public void Test_FuelAmountGetterShouldGetFuelAmount()
        {
            Assert.AreEqual(typeof(Car).GetField("fuelAmount", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(car), car.FuelAmount);
        }

        [TestCase(-1)]
        [TestCase(-1000)]
        public void Test_FuelAmountSetterShouldThrowWhenNegative(int negativeAmount)
        {
            Assert.Throws<TargetInvocationException>(() => typeof(Car).GetProperty("FuelAmount")!.SetMethod!.Invoke(car, new object[] { negativeAmount }));
        }

        [TestCase(0.1)]
        [TestCase(5)]
        [TestCase(11.1)]
        public void Test_RefuelShouldAddFuel(double fuel)
        {
            car.Refuel(fuel);
            Assert.AreEqual(fuel, car.FuelAmount);
        }

        [TestCase(11.2)]
        [TestCase(100)]
        public void Test_RefuelShouldNotAddMoreThanCapacity(double fuel)
        {
            car.Refuel(fuel);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-100)]
        public void Test_RefuelNegativeOr0ShouldThrow(double negativeFuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(negativeFuel));
        }

        [TestCase(0)]
        [TestCase(370)]
        [TestCase(739)]
        public void Test_DriveShouldDecreaseFuel(double distance)
        {
            car.Refuel(carFuelCapacity);
            car.Drive(distance);

            Assert.AreEqual(carFuelCapacity - distance / 100 * car.FuelConsumption, car.FuelAmount);
        }

        [TestCase(1)]
        [TestCase(100)]
        public void Test_DriveWithNoFuelShouldThrow(double distance)
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}