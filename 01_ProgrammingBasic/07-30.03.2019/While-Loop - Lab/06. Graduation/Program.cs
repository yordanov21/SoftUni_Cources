﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 1;
            double sum = 0;
            double avaverage = 0;
            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
               
                if (grade >= 4)
                {
                    sum += grade;
                    counter++;
                    avaverage = sum / 12;
                }
                    
            }
            Console.WriteLine($"{name} graduated. Average grade: {avaverage:f2}");
        }
    }
}
