using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        

        private Dictionary<string, UnitRider> riders;
        [SetUp]
        public void Setup()
        {
            this.riders = new Dictionary<string, UnitRider>();
        }

        [Test]
        public void ConstructorShouldInicialCorrectly()
        {
            var ridersTest = new Dictionary<string, UnitRider>();

            Assert.That(riders, Is.EqualTo(ridersTest));
        }

        [Test]
        public void CountShouldCorrectllyReturnCount()
        {
            RaceEntry raceEntry = new RaceEntry();

           raceEntry.AddRider(new UnitRider("rgacer1", new UnitMotorcycle("kavazaki", 100, 1000)));
           raceEntry.AddRider(new UnitRider("rgacer2", new UnitMotorcycle("kavazaki", 100, 1000)));
           raceEntry.AddRider(new UnitRider("rgacer3", new UnitMotorcycle("kavazaki", 100, 1000)));
           raceEntry.AddRider(new UnitRider("rgacer4", new UnitMotorcycle("kavazaki", 100, 1000)));
           raceEntry.AddRider(new UnitRider("rgacer5", new UnitMotorcycle("kavazaki", 100, 1000)));
              
            int actualCount =raceEntry.Counter;
            int expectedCount = 5;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void AddRiderSholudThrowInvalidOperationExceptionIfRiderIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitRider rider = null;

            Assert
                .Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRiderSholudThrowInvalidOperationExceptionIfContainRider()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitRider rider = new UnitRider("rader1", new UnitMotorcycle("kavazaki", 100, 1000));
            raceEntry.AddRider(rider);
            Assert
                .Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));
        }

        [Test]
        public void AddRiderSholudAddCorrectly()
        {

            RaceEntry raceEntry = new RaceEntry();
            UnitRider rider = new UnitRider("rader1", new UnitMotorcycle("kavazaki", 100, 1000));
            //raceEntry.AddRider(rider);
          
            string expectedresult = string.Format("Rider {0} added in race.",rider.Name);

            Assert.That(raceEntry.AddRider(rider), Is.EqualTo(expectedresult));
                  
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldThrowInvalidOperationExceptionIfRiderCountIsLessThanMinParticipants()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitRider rider = new UnitRider("rader1", new UnitMotorcycle("kavazaki", 100, 1000));
            raceEntry.AddRider(rider);
            Assert
                .Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePowerMethodShouldCalculateCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitRider rider1 = new UnitRider("rader1", new UnitMotorcycle("kavazaki", 100, 1000));
            UnitRider rider2 = new UnitRider("rader2", new UnitMotorcycle("kavazaki", 250, 1000));
            UnitRider rider3 = new UnitRider("rader3", new UnitMotorcycle("kavazaki", 250, 1000));
            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);
            raceEntry.AddRider(rider3);

            double expectedHourePower = 200;
            double actualHourePower = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedHourePower, actualHourePower);
        }
   
    }
}