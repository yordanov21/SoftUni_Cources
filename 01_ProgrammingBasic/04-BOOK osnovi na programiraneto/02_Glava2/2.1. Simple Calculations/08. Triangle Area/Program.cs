using System;

namespace _08._Triangle_Area
{
    class Program
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var h = double.Parse(Console.ReadLine());
            var area = (a * h) / 2;

            Console.WriteLine("Triangle area = {0}",area);
        }
    }
}
