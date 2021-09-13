using System;

namespace _10._Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rad = double.Parse(Console.ReadLine());
            var degree = Math.Round((rad / Math.PI) * 180);
            Console.WriteLine(degree);

        }
    }
}
