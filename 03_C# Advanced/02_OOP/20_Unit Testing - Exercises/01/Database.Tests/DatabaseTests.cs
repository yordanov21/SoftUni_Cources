using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            int expectedCount = 16;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]      
  
        public void ConstructorShouldThrowInvalidOprtationExeptionIsNotExactly16()
        {
            int[] array = new int[17];
        Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void AddMethodShouldIncreaseTheCount()
        {
            Database database = new Database();
            database.Add(1);
            int exeptedCount = 1;
            int actualCount = database.Count;

            Assert.AreEqual(exeptedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldAddOnTheNextEmptyIndex()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);
            database.Add(6);

            int expectedResult = 6;
            int actualResult = database.Fetch()[5];

            Assert.AreEqual(expectedResult, actualResult);
            
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenElementsAreExceeded()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]

        public void ShouldRemoveCorrectlyAndDecreaseCount()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            database.Remove();

            int expectedCount =2;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]

        public void ShouldRemoveCorrectlyLastElement()
        {
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);
            database.Remove();

            int expectedValue = 2;
            int actualValue = database.Fetch()[1];

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExeprion()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchmethodShouldReturnAllElementAsArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Database database = new Database(array);

            int[] expectedValues = { 1, 2, 3, 4, 5 };
            int[] actualValues = database.Fetch();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}