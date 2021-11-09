using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Queue<int> evenNumbers = new Queue<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                if (currentNum % 2 == 0)
                {
                    evenNumbers.Enqueue(currentNum);
                }
            }

            var evenNumbersForprint = evenNumbers.ToArray();

            Console.WriteLine(String.Join(", ",evenNumbersForprint));
        }
    }
}
