using System;

namespace _01._Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());

            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());


            int a = Math.Abs(x2 - x3);
            int ha = Math.Abs(y1 - y2);

            double area = a * ha / 2.0;

            Console.WriteLine(area);
        }
    }
}
