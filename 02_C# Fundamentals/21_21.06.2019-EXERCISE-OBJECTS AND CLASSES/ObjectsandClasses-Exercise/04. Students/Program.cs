using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();
            for (int i = 0; i < countStudents; i++)
            {
                string[] studentArr = Console.ReadLine().Split();

                string firstName = studentArr[0];
                string lastName = studentArr[1];
                double grade = double.Parse(studentArr[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}