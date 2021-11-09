namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    public class PresentsTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void PresentConstructorShouldInizializaidCorrectly()
        {
            string name = "present1";
            double magic = 20;

            Present present = new Present(name, magic);
            Assert.AreEqual(name, present.Name);
            Assert.AreEqual(magic, present.Magic);
         
        }

        [Test]
        public void BagConstructorShouldInizializaidCorrectly()
        {
            string name = "present1";
            double magic = 20;

            Present present = new Present(name, magic);
            Bag bag = new Bag();
                     
            Assert.AreEqual(bag, bag);
        
        }



        [Test]
        public void CreateMethodShouldThrowArgumentNullException()
        {
            string name = "present1";
            double magic = 20;

            Present present = null;
            Bag bag = new Bag();


            Assert
           .Throws<ArgumentNullException>(() => bag.Create(present));

        }

        [Test]
        public void CreateMethodShouldThrowInvalidOperationException()
        {
            string name = "present1";
          
            double magic = 20;

            Present present = new Present(name, magic);
           
            Bag bag = new Bag();
            bag.Create(present);

            Assert
           .Throws<InvalidOperationException>(() => bag.Create(present));

        }

        [Test]
        public void CreateMethodShouldWorkCorrectly()
        {
            string name = "present1";
            string name2 = "present2";
            string name3 = "present3";

            double magic = 20;

            Present present = new Present(name, magic);
            Present present2 = new Present(name2, magic);
            Present present3 = new Present(name3, magic);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            int expectedCount = 3;
            Assert.That(bag.GetPresents().Count, Is.EqualTo(expectedCount));
        }


        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            string name = "present1";
            string name2 = "present2";
            string name3 = "present3";

            double magic = 20;

            Present present = new Present(name, magic);
            Present present2 = new Present(name2, magic);
            Present present3 = new Present(name3, magic);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
            bag.Remove(present);
            int expectedCount = 2;
            Assert.That(bag.GetPresents().Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetPresentWithLeastMagicMethodShouldWorkCorrectly()
        {
            string name = "present1";
            string name2 = "present2";
            string name3 = "present3";

            double magic = 20;
            double magic2 = 10;
            double magic3 = 40;

            Present present = new Present(name, magic);
            Present present2 = new Present(name2, magic2);
            Present present3 = new Present(name3, magic3);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);
         
            double expectedMagic = magic2;
            Assert.That(bag.GetPresentWithLeastMagic().Magic, Is.EqualTo(expectedMagic));
            Assert.That(bag.GetPresentWithLeastMagic(), Is.EqualTo(present2));
        }
        

        [Test]
        public void GetPresentMethodShouldWorkCorrectly()
        {
            string name = "present1";
            string name2 = "present2";
            string name3 = "present3";

            double magic = 20;
            double magic2 = 10;
            double magic3 = 40;

            Present present = new Present(name, magic);
            Present present2 = new Present(name2, magic2);
            Present present3 = new Present(name3, magic3);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            string expectedName = "present3";
            Assert.That(bag.GetPresent("present3"), Is.EqualTo(present3));
            Assert.That(bag.GetPresent("present3").Name, Is.EqualTo(expectedName));
        }
   
    }
}
