using System;

namespace _05._Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double ha = double.Parse(Console.ReadLine());

            double area = triangleArea(a, ha);
            Console.WriteLine(area);
        }

        static double triangleArea(double length, double height)
        {
            return(length*height)/2;
        }
    }
}
