using NUnit.Framework;

namespace Tests
{
    using Database;
    using System;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInicializaidWith16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]

        public void ConstructorShouldThrowInvalidOperationExceptionWhhenIsNot16()
        {
            int[] array = new int[17];
            Assert
                .Throws<InvalidOperationException>(() => new Database(array));

        }

       [Test]
       public void AddMethodShouldAddCorrectlyAndIncreasdCount()
        {
            int[] array = new int[10];
            Database database = new Database(array);
            database.Add(1);
            int expectedCount = 11;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenElementsAreExceeded()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            Assert
                .Throws<InvalidOperationException>(() => database.Add(1));

        }

        [Test]
        public void ShouldRemoveCottectly()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            database.Remove();
            int expectedCount = 15;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ShouldRemoveCottectlyLastElement()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            database.Remove();
            int expectedElementValue = 0;
            int actualValue = database.Fetch()[1];

            Assert.AreEqual(expectedElementValue, actualValue);
        }

        [Test]
        public void ShouldRemoveThrowInvalidOperationExceptionWhenTheCountIsZero()
        {
            int[] array = new int[1];
            Database database = new Database(array);
            database.Remove();
            Assert
                  .Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnAllElementAsArray()
        {
            int[] array = { 1, 5, 2, 4, 5 };
            Database database = new Database(array);

            int[] expectedValues = { 1, 5, 2, 4, 5 };
            int[] actualValues = database.Fetch();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}