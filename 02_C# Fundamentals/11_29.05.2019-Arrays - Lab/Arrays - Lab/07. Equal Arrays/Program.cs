using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumDifferenceElements = 0;
            int sumElements = 0;
            int[] numbers1 = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] numbers2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < numbers1.Length; i++)
            {
                if (numbers1[i] != numbers2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }

                sumElements += numbers1[i];
              
            }
            
                Console.WriteLine($"Arrays are identical. Sum: {sumElements}");
            
        }
    }
}
