namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private SoftPark softPark; //изнасяме си го в глобална променлива; 

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void ConstructorShouldCreateTwelveEmptyParkingSpots()
        {
    
            Assert.That(softPark.Parking.Count, Is.EqualTo(12));
        }

        [Test]
        public void ConstructorShouldCreateCorrectSpots()
        {

           var myParking = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            foreach (var kvp in this.softPark.Parking)
            {
                Assert.That(myParking.ContainsKey(kvp.Key), Is.EqualTo(true));
                Assert.That(myParking[kvp.Key], Is.EqualTo(null)) ;
            }
        }

        [Test]
        public void 
    }
}