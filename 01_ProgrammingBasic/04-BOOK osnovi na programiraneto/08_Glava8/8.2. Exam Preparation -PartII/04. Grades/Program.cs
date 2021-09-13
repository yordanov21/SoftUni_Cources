using System;

namespace _04._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int topStudentCount = 0;
            int bet4and5StudentsCount = 0;
            int bet3and4StudentsCount = 0;
            int failStudentCount = 0;
            double sumGrade = 0;


            for (int i = 1; i <= students; i++)
            {
                double curentGrade = double.Parse(Console.ReadLine());

                sumGrade += curentGrade;
                if (curentGrade >= 5.00)
                {
                    topStudentCount++;
                }
                else if (curentGrade >= 4.00 && curentGrade < 5)
                {
                    bet4and5StudentsCount++;
                }
                else if (curentGrade >= 3 && curentGrade < 4)
                {
                    bet3and4StudentsCount++;
                }
                else
                {
                    failStudentCount++;
                }
            }

            double topStudentPercent =(double) topStudentCount / students * 100.0;
            double bet4and5StudentPrecent = (double)bet4and5StudentsCount / students * 100.0;
            double bet3and4StudentPrecent = (double)bet3and4StudentsCount / students * 100.0;
            double failStudentPercent = (double)failStudentCount / students * 100.0;

            double average = sumGrade / students;

            Console.WriteLine($"Top students: {topStudentPercent:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {bet4and5StudentPrecent:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {bet3and4StudentPrecent:f2}%");
            Console.WriteLine($"Fail: {failStudentPercent:f2}%");
            Console.WriteLine($"Average: {average:f2}");

        }
    }
}
