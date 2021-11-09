namespace Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExtendedDatabaseTests
    {
        private Person pesho;
        private Person gosho;

        [SetUp]
        public void TestInit()
        {
            pesho = new Person(114560, "Pesho");
            gosho = new Person(447788556699, "Gosho");
        }

        //[Test]
        //public void ConstructorShoudInitializeCollection()
        //{
        //    Person[] expected = new Person[] { pesho, gosho };

        //   ExtendedDatabase db = new ExtendedDatabase(expected);

        //    var actual = db.Fetch();

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        //[Test]
        //public void AddShouldAddValidPerson()
        //{
        //    var persons = new Person[] { pesho, gosho };
        //    var db = new ExtendedDatabase(persons);
        //    var newPerson = new Person(554466, "Stamat");
        //    db.Add(newPerson);

        //    var actual = db.Fetch();
        //    var expected = new Person[] { pesho, gosho, newPerson };

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        [Test]
        public void AddSameUsernameShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(554466, "Gosho");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        [Test]
        public void AddSameIdShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);
            var newPerson = new Person(114560, "Stamat");

            Assert.That(() => db.Add(newPerson), Throws.InvalidOperationException);
        }

        //[Test]
        //public void RemoveShouldRemove()
        //{
        //    var persons = new Person[] { pesho, gosho };
        //    var db = new ExtendedDatabase(persons);
        //    db.Remove();

        //    var actual = db.
        //    var expected = new Person[] { pesho };

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

        [Test]
        public void RemoveEmptyCollectionShouldThrow()
        {
            var persons = new Person[] { };
            ExtendedDatabase db = new ExtendedDatabase(persons);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindByUsername("Pesho");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByUsernameNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("Stamat"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameIsCaseSensitive()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindByUsername("GOSHO"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdExistingPersonShouldReturnPerson()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            var expected = pesho;
            var actual = db.FindById(114560);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindByIdNonExistingPersonShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(558877), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNegativeArgumentShouldThrow()
        {
            var persons = new Person[] { pesho, gosho };
            var db = new ExtendedDatabase(persons);

            Assert.That(() => db.FindById(-5), Throws.Exception);
        }
    }
}