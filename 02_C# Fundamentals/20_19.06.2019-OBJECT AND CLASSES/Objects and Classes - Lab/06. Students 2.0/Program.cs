﻿using System;
using System.Collections.Generic;

namespace _06._Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string city = tokens[3];

                if (IsStudentExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);
                    student.Age = age;
                    student.City = city;
                }
                else
                {
                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city,

                    };

                    students.Add(student);
                }
            }

                string filterCity = Console.ReadLine();
                foreach (Student student in students)
                {
                    if (student.City == filterCity)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} is { student.Age} years old.");
                    }
                }
            
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }

        static bool IsStudentExisting(List<Student> students,string firstName, string lastName)
        {
            foreach(Student student in students)
            {
                if(student.FirstName== firstName&& student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }
         
        static Student GetStudent(List<Student> students,string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach(Student student in students)
            {
                if(student.FirstName==firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                   
                    
                }
            }
            return existingStudent;
        }
    }
}
