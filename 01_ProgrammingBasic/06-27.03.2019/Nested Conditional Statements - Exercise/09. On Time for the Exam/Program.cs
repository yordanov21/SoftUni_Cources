using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            double hourExam = double.Parse(Console.ReadLine());
            double minuteExam = double.Parse(Console.ReadLine());
            double hourArive = double.Parse(Console.ReadLine());
            double minuteArive = double.Parse(Console.ReadLine());

            double StartExam = hourExam * 60 + minuteExam;
            double AriveExam = hourArive * 60 + minuteArive;

            if (StartExam < AriveExam)
            {

                double differense = AriveExam - StartExam;
                if (differense < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{differense} minutes after the start");
                }
                else if (differense >= 60)
                {
                    double hours = Math.Floor(differense / 60);
                    double minutes = differense % 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                    }

                }
            }
            else if ((StartExam - AriveExam) <= 30 || StartExam == AriveExam)
            {
                if (StartExam == AriveExam)
                {
                    Console.WriteLine("On time");
                }
                else
                {
                    double differense = StartExam - AriveExam;
                    Console.WriteLine("On time");
                    Console.WriteLine($"{differense} minutes before the start");
                }
            }
            else if ((StartExam - AriveExam) > 30)
            {

                double differense = StartExam- AriveExam;
                if (differense < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{differense} minutes before the start");
                }
                else if (differense >= 60)
                {
                    double hours = Math.Floor(differense / 60);
                    double minutes = differense % 60;
                    if (minutes < 10)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{hours}:0{minutes} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{hours}:{minutes} hours before the start");
                    }

                }
            }
        }
    }
}

