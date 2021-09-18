using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                 .Split()
                 .Select(double.Parse)
                 .ToList();
            for (int i = 0; i < numbers.Count-1; i++)
            {
                numbers[i] = numbers[i] + numbers[numbers.Count -1];
                numbers.Remove(numbers[numbers.Count-1]);
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
