using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsInformation = new Dictionary<string, List<double>>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());

                if (!studentsInformation.ContainsKey(studentName))
                {
                    studentsInformation.Add(studentName, new List<double>());

                }
                studentsInformation[studentName].Add(studentGrade);
            }

            studentsInformation = studentsInformation
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine(string.Join(Environment.NewLine, studentsInformation.Select(x => $"{x.Key} -> {x.Value.Average():f2}")));
        }
    }
}
