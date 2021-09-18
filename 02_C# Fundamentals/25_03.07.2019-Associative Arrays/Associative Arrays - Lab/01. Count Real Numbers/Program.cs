using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                  .Split()
                  .Select(double.Parse)
                  .ToArray();
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            
            foreach(int number in numbers)
            {
                if (!counts.ContainsKey(number))
                {
                    counts.Add(number, 1);
                    //counts[number] = 1; същото записано по различен начин.
                }
                else
                {
                    counts[number]++;
                }
            }

            foreach(var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
