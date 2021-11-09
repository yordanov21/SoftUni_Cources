using System;

namespace _06TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine(AreaByTreeSides(a,b,c));
        }
        static double AreaByTreeSides(double a, double b, double c)
        {

            double p = (a + b + c)/2;         
            double area = Math.Sqrt(p*(p-a)*(p-b)*(p-c));

            return area;
        }
    }
}
