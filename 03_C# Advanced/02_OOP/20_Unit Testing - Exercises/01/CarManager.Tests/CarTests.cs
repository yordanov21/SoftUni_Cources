namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    using System;

    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(fuelCosumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            
        }

        [Test]
        public void ModelShouldThrowArgumentExeptionWhenNameIsNUll()
        {
            string make = "VW";
            string model = null;
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCosumption, fuelCapacity));
          
        }

        [Test]
        public void MakeShouldThrowArgumentExeptionWhenNameIsNUll()
        {
            string make = null;
            string model ="Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCosumption, fuelCapacity));

        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExeptionWhenIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCosumption, fuelCapacity));

        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExeptionWhenIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 10;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCosumption, fuelCapacity));

        }

        [Test]
        public void FuelCapacityShouldThrowArgumentExeptionWhenBellowZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 10;
            double fuelCapacity = -10;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelCosumption, fuelCapacity));

        }

        [Test]
        [TestCase(null,"Golf",10,20)]
        [TestCase("VW",null,10,20)]
        [TestCase("VW","Golf",-10,20)]
        [TestCase("VW","Golf",0,20)]
        [TestCase("VW","Golf",10,-20)]
        [TestCase("VW","Golf",10,0)]
        public void AllPropertiesShouldThrowArgumentExeptionForInvalidValues
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormanly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
            car.Refuel(10);

            double expectedFuelAmount = 10;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
            car.Refuel(150);

            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void ShouldRefuelThrowArgumentExeptionWhenInputAmountIsBellowZero(double inputAmount)
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
           
            Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount));
        }

        [Test]
        public void ShouldDriveNormanlly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
            car.Refuel(20);
            car.Drive(20);

            double expectedFuelAmount = 19.6;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


        [Test]
        public void ShouldDriveThrowInvalidOperationExeptionWheFuelAmountIsNotEnough()
        {
            string make = "VW";
            string model = "Golf";
            double fuelCosumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelCosumption, fuelCapacity);
            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}