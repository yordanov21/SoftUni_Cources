using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumOdd += number;
                }
                else
                {
                    sumEven += number;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine($"Yes \nSum = {sumEven}");
            }
            else
            {
                Console.WriteLine($"No \nDiff = {Math.Abs(sumEven-sumOdd)}");
            }
        }
    }
}
