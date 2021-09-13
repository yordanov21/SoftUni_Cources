using System;

namespace _06._Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var radius = double.Parse(Console.ReadLine());

            var area = Math.PI * radius * radius;
            var perimetur = 2 * Math.PI * radius;

            Console.WriteLine("Area = "+area);
            Console.WriteLine("Perimeter = "+perimetur);
        }
    }
}
