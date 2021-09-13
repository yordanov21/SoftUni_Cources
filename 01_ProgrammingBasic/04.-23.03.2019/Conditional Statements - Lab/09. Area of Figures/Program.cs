﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0.0;
            switch (figureType)
            {
                case "square": 
                    {
                        double a = double.Parse(Console.ReadLine());
                        area = a * a;
                        break;
                    }
                case "rectangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double b = double.Parse(Console.ReadLine());
                        area = a * b;
                        break;

                    }
                case "circle":
                    {
                        double r = double.Parse(Console.ReadLine());
                        area = Math.PI * r * r;
                        break;
                    }
                case "triangle":
                    {
                        double a = double.Parse(Console.ReadLine());
                        double h = double.Parse(Console.ReadLine());
                        area = a * h / 2;
                        break;
                    }
                   
            }
            Console.WriteLine($"{area:f3}");

        }
    }
}
