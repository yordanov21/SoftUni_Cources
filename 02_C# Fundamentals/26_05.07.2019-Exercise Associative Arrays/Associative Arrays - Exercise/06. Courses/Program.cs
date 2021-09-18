using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courseDict = new Dictionary<string, List<string>>();
            List<string> student = new List<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                string[] courses = command.Split(" : ");

                string courseName = courses[0];
                string studentName = courses[1];

                if (!courseDict.ContainsKey(courseName))
                {
                    student.Add(studentName);
                    courseDict.Add(courseName, student);
                    student = new List<string>();
                }
                else
                {
                    courseDict[courseName].Add(studentName);
                }
            }

            courseDict= courseDict.OrderByDescending(x => x.Value.Count).ToDictionary(a => a.Key, b => b.Value);
           foreach(var courses in courseDict)
            {
                Console.WriteLine($"{courses.Key}: {courses.Value.Count}");
                foreach(var name in courses.Value.OrderBy(n=>n))
                {
                    Console.WriteLine("-- {0}", name);
                }
               
            }
        }
    }   
}
