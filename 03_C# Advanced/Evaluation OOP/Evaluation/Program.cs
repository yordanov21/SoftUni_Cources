using System;

namespace Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C#Advanced Evaluation");
            Console.WriteLine();
            Console.WriteLine("Enter your points on the exam:");
            int points = int.Parse(Console.ReadLine());
            double precentOfPoints = points / 300.0*100;

            Console.WriteLine("Enter your precent of Teory Exam:");
            double precentOfTeory = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your presences:(number between 1-24)");
            double precences = double.Parse(Console.ReadLine());
            Console.WriteLine();
            double precentOfBonus =(double)(precences / 24.0)*5.0;

            Console.WriteLine("Enter your homeworks(num betwen 1-7)");
            double homeWork = double.Parse(Console.ReadLine());
            Console.WriteLine();
            double homeWorkBonus = homeWork / 7.0*5;
            double allprecents = precentOfPoints*0.9 + precentOfTeory + precentOfBonus+ homeWorkBonus;

            if (allprecents < 50)
            {
                Console.WriteLine(allprecents+"%");
                Console.WriteLine("2.00");
            }
            else if(allprecents>=100)
            {
                Console.WriteLine("6.00");
                Console.WriteLine($"{allprecents:f2}" + "%");
            }
            else
            {
                Console.WriteLine($"{allprecents:f2}"+"%");
                double evaluation = (allprecents - 50) * 0.06 + 3;
                Console.WriteLine(Math.Round(evaluation, 2));
            }
                

        }
    }
}
