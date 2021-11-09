using System;

namespace example4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person.PrintNameAndAge("Pesho", 25);
        }
    }

    class Person
    {
        public static void PrintNameAndAge(string name, int age)
        {
            Console.WriteLine($"I am {name}, {age} years old.");
        }
    }
}
