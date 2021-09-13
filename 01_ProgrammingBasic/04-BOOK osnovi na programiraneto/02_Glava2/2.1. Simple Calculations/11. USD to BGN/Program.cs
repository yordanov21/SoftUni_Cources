using System;

namespace _11._USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            var usd = double.Parse(Console.ReadLine());

            var leva = usd * 1.79549;

            Console.WriteLine($"{leva:f2}");
        }
    }
}
