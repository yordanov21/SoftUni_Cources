namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ConstructorShouldInizializaidCorrectly()
        {
            string name = "aqua";
            int capacity = 50;

            Aquarium aquarium = new Aquarium(name, capacity);
            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }


        [Test]
        public void NamePropShouldThrowArgumentNullExceptionIfISNull()
        {
            string name = null;
            int capacity = 50;

            Assert
           .Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void NamePropShouldThrowArgumentNullExceptionIfISEmpty()
        {
            string name = "";
            int capacity = 50;

            Assert
           .Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void CapacityPropShouldThrowArgumentNullExceptionIfIsNegative()
        {
            string name = "aqua";
            int capacity = -10;

            Assert
           .Throws<ArgumentException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfCoutIsEcualToCapacity()
        {
            string name = "Aqua";
            int capacity = 3;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
            Fish fish4 = new Fish("Nemo4");
          
           Aquarium aquarium= new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
          
            Assert
                .Throws<InvalidOperationException>(() =>aquarium.Add(fish4));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            string name = "Aqua";
            int capacity = 10;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
            Fish fish4 = new Fish("Nemo4");

            Aquarium aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);
            int expectedCount = 4;

            Assert.That(aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationException()
        {
            string name = "Aqua";
            int capacity = 10;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
            Fish fish4 = new Fish("Nemo4");

            Aquarium aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            Assert
                   .Throws<InvalidOperationException>(() => aquarium.RemoveFish("pesho"));
        }

        //[Test]
        //public void RemoveMethodShouldWorkCorrectly()
        //{
        //    string name = "Aqua";
        //    int capacity = 10;
        //    Fish fish1 = new Fish("Nemo");
        //    Fish fish2 = new Fish("Nemo2");
        //    Fish fish3 = new Fish("Nemo3");
        //    Fish fish4 = new Fish("Nemo4");
    
        //    Aquarium aquarium = new Aquarium(name, capacity);
        //    aquarium.Add(fish1);
        //    aquarium.Add(fish2);
        //    aquarium.Add(fish3);
        //    aquarium.Add(fish4);
        //    aquarium.RemoveFish("Nemo4");
        //    int expectedCount = 3;
        //    Assert.AreEqual(expectedCount, Is.EqualTo(aquarium.));

        //}


        [Test]
        public void SellFishMethodShloudThowInvalidOperationExceptionIfFishIsNull()
        {
            string name = "Aqua";
            int capacity = 10;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
            Fish fish4 = new Fish("Nemo4");

            Aquarium aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            Assert
                   .Throws<InvalidOperationException>(() => aquarium.SellFish("pesho"));
        }

        [Test]
        public void SellFishMethodShloudWorkCorrectlyl()
        {
            string name = "Aqua";
            int capacity = 10;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
            Fish fish4 = new Fish("Nemo4");

            Aquarium aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);
            aquarium.Add(fish4);

            var expectedFishToSell = fish4;

            Assert.That(aquarium.SellFish("Nemo4"), Is.EqualTo(expectedFishToSell));
        }


        [Test]
        public void ReportShloudWorkCorrectly()
        {
            string name = "Aqua";
            int capacity = 10;
            Fish fish1 = new Fish("Nemo");
            Fish fish2 = new Fish("Nemo2");
            Fish fish3 = new Fish("Nemo3");
         

            Aquarium aquarium = new Aquarium(name, capacity);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            
            string expectedReport= $"Fish available at {aquarium.Name}: Nemo, Nemo2, Nemo3";
            Assert.AreEqual(expectedReport, aquarium.Report());
        }
    
    }
}
