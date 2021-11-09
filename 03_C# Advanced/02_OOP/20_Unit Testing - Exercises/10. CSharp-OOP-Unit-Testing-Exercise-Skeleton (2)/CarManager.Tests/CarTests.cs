using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldInicializaidConstructorCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);

        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;
           
            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsBellowZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -2;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenIsBellowZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = -100;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExceptionWhenIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 0;

            Assert
                .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(null,"Golf",10,20)]
        [TestCase("VW",null,10,20)]
        [TestCase("VW","Golf",-10,20)]
        [TestCase("VW","Golf",0,20)]
        [TestCase("VW","Golf",10,-20)]
        [TestCase("VW","Golf",10,0)]
      
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert
               .Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormanlly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);

            double expectedFuelAmount =10;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualAmount);
        }
        [Test]
        public void WhenFUelToRefuelIsNegativeValue()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                .Throws<ArgumentException>(() => car.Refuel(-10));
        }

        [Test]
        public void WhenFUelToRefuelIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                .Throws<ArgumentException>(() => car.Refuel(0));
        }
        [Test]
        public void WhenFUelToRefuelIsBiggerThenFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(110);

            double expectedFuelAmount = car.FuelCapacity;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualAmount);
        }

        [Test]
        public void DriveMethodShouldThrolInvalidOperationException()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert
                .Throws<InvalidOperationException>(() => car.Drive(10));
        }
        [Test]
        public void ShouldDriveNormanly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualAmount);

        }
     
    }
}