using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int curentNum = numbers[i];
                for (int j = i+1; j < numbers.Length; j++)
                {
                    int sumEqual = curentNum + numbers[j];
                    if (sum == sumEqual)
                    {
                        Console.WriteLine(numbers[i]+" "+numbers[j]);
                    }
                }
            }

        }
    }
}
