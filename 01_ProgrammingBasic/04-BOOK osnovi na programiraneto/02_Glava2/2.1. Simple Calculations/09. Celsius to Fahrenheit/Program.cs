using System;

namespace _09._Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var gradus = double.Parse(Console.ReadLine());

            var far = gradus*1.8 + 32;
            Console.WriteLine(far);

        }
    }
}
