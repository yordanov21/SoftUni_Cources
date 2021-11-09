namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
       [SetUp]
       public void SetUp()
        {

        }

        [Test]
        public void ConstructorShouldInizializaidCorrectly()
        {
            string name = "Orion";
            int capacity = 10;
       
            Spaceship spaceship = new Spaceship(name, capacity);
            Assert.AreEqual(name, spaceship.Name);
            Assert.AreEqual(capacity, spaceship.Capacity);
          
        }

        [Test]
        public void NamePropShouldThrowArgumentNullExceptionIfISNull()
        {
            string name = null;
            int capacity = 10;
           
            Assert
           .Throws<ArgumentNullException>(() =>new Spaceship(name,capacity));
        }

        [Test]
        public void NamePropShouldThrowArgumentNullExceptionIfNameIsEmpty()
        {
            string name = "";
            int capacity = 10;

            Assert
           .Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }

     
        [Test]
        public void CapacityPropShouldThrowArgumentNullExceptionIfIsNegative()
        {
            string name = "Orion";
            int capacity = -10;

            Assert
           .Throws<ArgumentException>(() => new Spaceship(name, capacity));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfCoutIsEcualToCapacity()
        {
            string name = "Orion";
            int capacity = 3;
            Astronaut astronaut1 = new Astronaut("Astro1", 100);
            Astronaut astronaut2 = new Astronaut("Astro2", 100);
            Astronaut astronaut3 = new Astronaut("Astro3", 100);
            Astronaut astronaut4 = new Astronaut("Astro4", 100);
            Spaceship spaceship = new Spaceship(name, capacity);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);

            Assert
                .Throws<InvalidOperationException>(() => spaceship.Add(astronaut4));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfAstronautExist()
        {
            string name = "Orion";
            int capacity = 5;
            Astronaut astronaut1 = new Astronaut("Astro1", 100);
            Astronaut astronaut2 = new Astronaut("Astro2", 100);
            Astronaut astronaut3 = new Astronaut("Astro3", 100);
            Astronaut astronaut4 = new Astronaut("Astro4", 100);
            Spaceship spaceship = new Spaceship(name, capacity);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);

            Assert
                .Throws<InvalidOperationException>(() => spaceship.Add(astronaut3));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            string name = "Orion";
            int capacity = 5;
            Astronaut astronaut1 = new Astronaut("Astro1", 100);
            Astronaut astronaut2 = new Astronaut("Astro2", 100);
            Astronaut astronaut3 = new Astronaut("Astro3", 100);
            Astronaut astronaut4 = new Astronaut("Astro4", 100);
            Spaceship spaceship = new Spaceship(name, capacity);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);
            spaceship.Add(astronaut4);

            int expectedCount = 4;
            Assert.That(spaceship.Count, Is.EqualTo(expectedCount));
        }



        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            string name = "Orion";
            int capacity = 5;
            Astronaut astronaut1 = new Astronaut("Astro1", 100);
            Astronaut astronaut2 = new Astronaut("Astro2", 100);
            Astronaut astronaut3 = new Astronaut("Astro3", 100);
            Astronaut astronaut4 = new Astronaut("Astro4", 100);
            Spaceship spaceship = new Spaceship(name, capacity);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);
            spaceship.Add(astronaut4);

            bool expectedValue = true;
            Assert.AreEqual(spaceship.Remove("Astro3"), expectedValue);
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectlyIfIsFalse()
        {
            string name = "Orion";
            int capacity = 5;
            Astronaut astronaut1 = new Astronaut("Astro1", 100);
            Astronaut astronaut2 = new Astronaut("Astro2", 100);
            Astronaut astronaut3 = new Astronaut("Astro3", 100);
            Astronaut astronaut4 = new Astronaut("Astro4", 100);
            Spaceship spaceship = new Spaceship(name, capacity);
            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);
            spaceship.Add(astronaut3);
            spaceship.Add(astronaut4);

            bool expectedValue = false;
            Assert.AreEqual(spaceship.Remove("Astro10"), expectedValue);
           // Assert.That(spaceship.Remove("Astro10"), Is.EqualTo(expectedValue));
           //ѕроверката може да се запише и по двата начина!!!
        }
     
    }
}