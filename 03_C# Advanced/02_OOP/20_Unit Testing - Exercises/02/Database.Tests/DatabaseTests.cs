using NUnit.Framework;

namespace Tests
{
    using System;
    using ExtendedDatabase;
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(100000L, "Name1")]
        public void Test1(long id, string name)
        {
            var person = new Person(id, name);
            Assert.AreEqual(id, person.Id);
        }
        [TestCase(100000L, "Name1")]
        public void Test2(long id, string name)
        {
            var person = new Person(id, name);
            Assert.AreEqual(name, person.UserName);
        }
        [Test]
        public void Test2()
        {
            var data = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(data));
        }
        [Test]
        public void Test3()
        {
            var data = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            for (int i = 0; i < 16; i++)
            {
                var person = dataBase.FindById(100001L + i);
                Assert.AreEqual($"Name{i + 1}", person.UserName);
                person = dataBase.FindByUsername($"Name{i + 1}");
                Assert.AreEqual(100001L + i, person.Id);
            }
        }
        [TestCase(0)]
        [TestCase(7)]
        [TestCase(16)]
        public void Test4(int n)
        {
            var data = new Person[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            Assert.AreEqual(n, dataBase.Count);
        }
        [Test]
        public void Test5()
        {
            var data = new ExtendedDatabase(new Person(100000L, "Name1"));
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(100001L, "Name1")));
        }

        [Test]
        public void Test6()
        {
            var data = new ExtendedDatabase(new Person(100000L, "Name1"));
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(100000L, "Name2")));
        }
        [Test]
        public void Test7()
        {
            var data = new ExtendedDatabase();
            for (int i = 0; i < 16; i++)
            {
                data.Add(new Person(100001L + i, $"Name{i + 1}"));
            }
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(100017L, "Name17")));
        }
        [Test]
        public void Test8()
        {
            var data = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(16)]
        public void Test11(int n)
        {
            var data = new Person[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            dataBase.Remove();
            Assert.AreEqual(n - 1, dataBase.Count);
        }
        [Test]
        public void Test12()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            var person = dataBase.FindById(100005L);
            Assert.AreEqual(100005L, person.Id);
        }
        [Test]
        public void Test13()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            Assert.Throws<InvalidOperationException>(() => dataBase.FindById(100008L));
        }
        [Test]
        public void Test14()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            Assert.Throws<ArgumentOutOfRangeException>(() => dataBase.FindById(-1));
        }
        [Test]
        public void Test15()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            var person = dataBase.FindByUsername("Name3");
            Assert.AreEqual("Name3", person.UserName);
        }
        [Test]
        public void Test16()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            Assert.Throws<ArgumentNullException>(() => dataBase.FindByUsername(null));
        }
        [Test]
        public void Test17()
        {
            var data = new Person[7];
            for (int i = 0; i < 7; i++)
            {
                data[i] = new Person(100001L + i, $"Name{i + 1}");
            }
            var dataBase = new ExtendedDatabase(data);
            Assert.Throws<InvalidOperationException>(() => dataBase.FindByUsername("Name8"));
        }
    }
}