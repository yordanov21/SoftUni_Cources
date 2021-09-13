using System;

namespace _06._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine(CalculatePower(n, power));
        }

        static double CalculatePower(double number, double power)
        {
            return Math.Pow(number, power);

        }
    }
}
