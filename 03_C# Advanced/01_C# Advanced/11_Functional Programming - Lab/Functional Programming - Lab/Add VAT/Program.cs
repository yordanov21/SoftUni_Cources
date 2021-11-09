using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double,double> addVAT = n => n*1.2;
            Func<string, double> doubleParser = n =>double.Parse(n);

            double[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(doubleParser)
                .Select(addVAT)
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
            
        }
    }
}
