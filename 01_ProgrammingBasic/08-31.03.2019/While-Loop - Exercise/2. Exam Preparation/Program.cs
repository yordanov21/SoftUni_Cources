using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int possibleBadGrades = int.Parse(Console.ReadLine());

            int badGradesCount = 0;
            int totalGradesCount = 0;
            int gradeSum = 0;
            string lastProblem = string.Empty;

            while (badGradesCount < possibleBadGrades)
            {
                string command = Console.ReadLine();
                if (command == "Enough")
                {
                    break;
                }
                int currenGrade = int.Parse(Console.ReadLine());
                lastProblem = command;
                totalGradesCount++;
                gradeSum += currenGrade;

                if(currenGrade<=4)
                {
                    badGradesCount++;
                }    
            }

            if (badGradesCount == possibleBadGrades)
            {
                Console.WriteLine($"You need a break, {badGradesCount} poor grades.");
            }
            else
            {
                double averageScore=(double)gradeSum/ totalGradesCount;
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {totalGradesCount}");
                Console.WriteLine($"Last problem: {lastProblem}");    
            }
        }
    }
}
