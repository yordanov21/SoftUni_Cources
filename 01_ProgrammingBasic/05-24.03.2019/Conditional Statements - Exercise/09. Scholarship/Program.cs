using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double Salary = double.Parse(Console.ReadLine());
            double success = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double SocialScholarship = 0.35 * minSalary;
            double ExcellentScholarship = 25 * success;
            if (success < 4.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (Salary > minSalary && success < 5.50)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (success >= 5.50 && Salary > minSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(ExcellentScholarship)} BGN");
            }

            else if (Salary <= minSalary && success >= 5.50)
            {


                if (SocialScholarship > ExcellentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(SocialScholarship)} BGN");
                }

                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(ExcellentScholarship)} BGN");
                }

            }
            else if (Salary <= minSalary && success >= 4.50 && success<5.50)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(SocialScholarship)} BGN");

            }
        }
    }
}

