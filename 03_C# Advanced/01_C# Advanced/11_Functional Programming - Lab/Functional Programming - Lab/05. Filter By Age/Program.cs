using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(
                    new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person
                {
                    Name = name,
                    Age = age

                };
                people.Add(person);
            }

            string contition = Console.ReadLine();
            int ageContdition = int.Parse(Console.ReadLine());

            Func<Person, bool> fillterPredicate;
            if (contition == "older")
            {
                fillterPredicate = p => p.Age >= ageContdition;
            }
            else
            {
                fillterPredicate = p => p.Age < ageContdition;
            }

            string format = Console.ReadLine();

            Func<Person,string> selectFunc;

            if(format=="name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else
            {
                selectFunc = p => $"{p.Name}";
            }

            people
                .Where(fillterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
