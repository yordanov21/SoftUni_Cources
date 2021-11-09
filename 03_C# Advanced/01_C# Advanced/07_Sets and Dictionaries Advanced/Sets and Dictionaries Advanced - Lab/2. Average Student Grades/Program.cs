using System;
using System.Collections.Generic;
namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new Dictionary<string, List<double>>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var grade = double.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<double>();
                }
                grades[name].Add(grade);
            }

            foreach (var student in grades)
            {
                double sum = 0;
                var name = student.Key;
                var gradeList = student.Value;
                Console.Write(name + " -> ");
                foreach (double grade in gradeList)
                {
                    Console.Write($"{grade:f2} ");
                    sum += grade;
                }
                double avarage = sum / gradeList.Count;
                Console.Write($"(avg: {avarage:f2})");
                Console.WriteLine();
            }
        }
    }
}
