using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double sum = 0;
            double avaverage = 0;
            double excluded = 0;
            bool isExclided = false;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    excluded++;
                    avaverage = sum / 12;
                }
                else if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                    avaverage = sum / 12;     
                }
                if (excluded >= 2)
                {
                    isExclided = true;
                    break;
                }
            }
            if (isExclided == false)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avaverage:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {counter} grade");
            }
           
            
        }
    }
}
