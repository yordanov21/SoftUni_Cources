using System;

namespace _02._Grades
{
    class Program
    {

       private static void printRezult(double grade)
        {
            if (grade >= 2&&grade<3)
                Console.WriteLine("Fail");

            else if (grade >= 3 && grade < 3.50)
                Console.WriteLine("Poor");

            else if (grade >= 3.5 && grade < 4.50)
                Console.WriteLine("Good");

            else if (grade >= 4.50 && grade < 5.5)
                Console.WriteLine("Very good");

            else if(grade>=5.5&& grade<=6.0)
                Console.WriteLine("Excellent");

            else
                Console.WriteLine("Invalid input");

        }
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());
 
            printRezult(grade);
        }
    }
}
