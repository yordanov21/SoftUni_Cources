using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                double num = arr[i];
                if (!dict.ContainsKey(num))
                {
                    dict[num] = 1;
                }
                else
                {
                    dict[num]++;
                }
            }

            foreach (var item in dict)
            {
                double number = item.Key;
                int numberCount = item.Value;

                Console.WriteLine($"{number} - {numberCount} times");
            }

        }
    }
}
