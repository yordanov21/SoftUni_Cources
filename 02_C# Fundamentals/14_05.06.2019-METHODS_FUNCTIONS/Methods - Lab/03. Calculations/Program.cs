﻿using System;

namespace _03._Calculations
{
    class Program
    {
        private static void Add(int a, int b)
        {
            Console.WriteLine(a+b);
        }
        private static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        private static void Substract(int a, int b)
        {
            Console.WriteLine(a -b);
        }
        private static void Divide(int a, int b)
        {
            Console.WriteLine(a /b);
        }
        static void Main()
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            switch (command)
            {
                case "add":
                    Add(a, b);
                    break;
                case "multiply":
                    Multiply(a, b);
                    break;
                case "subtract":
                    Substract(a, b);
                    break;
                case "divide":
                    Divide(a, b);
                    break;

            }          
        }
    }
}
