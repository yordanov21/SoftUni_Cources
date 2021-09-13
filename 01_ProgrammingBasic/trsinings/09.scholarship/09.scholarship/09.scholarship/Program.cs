using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double incomeInLeva = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minimalSalary = double.Parse(Console.ReadLine());
            double SocialScholarship = Math.Floor(minimalSalary * 0.35);
            double ScholarshipForExcellentResults = Math.Floor(averageSuccess * 25);

             if (averageSuccess<4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (incomeInLeva > minimalSalary && averageSuccess < 5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (averageSuccess >= 5.5 && incomeInLeva > minimalSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {ScholarshipForExcellentResults} BGN");
            }
            else if (incomeInLeva <= minimalSalary && averageSuccess >= 5.50)
            {
                if (SocialScholarship > ScholarshipForExcellentResults)
                {
                    Console.WriteLine($"You get a Social scholarship {SocialScholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {ScholarshipForExcellentResults} BGN");
                }
            }
           
            else if (incomeInLeva <= minimalSalary && averageSuccess >= 4.50 && averageSuccess < 5.50)
            {
                Console.WriteLine($"You get a Social scholarship {SocialScholarship} BGN");
            }
           
           
        }
    }
}
