using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            List<Person> people = new List<Person>();
            while (line != "End")
            {
                string[] lineArr = line.Split();
                string name = lineArr[0];
                string id = lineArr[1];
                int age = int.Parse(lineArr[2]);

                Person person = new Person(name, id, age);

                people.Add(person);

                line = Console.ReadLine();
            }
            people = people.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.Id} is {this.Age} years old.";
        }
    }
}
