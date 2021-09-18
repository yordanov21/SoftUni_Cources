using System;

namespace _01._ConvertMeters_To_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double km = (double)meters / 1000;

            Console.WriteLine($"{km:f2}");
        }
    }
}
