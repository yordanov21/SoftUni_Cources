using System;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numberToCheck = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMaxNumber(numbers));

            Console.WriteLine(GetNumberCount(numberToCheck,numbers));
        }

        static int GetMaxNumber(params int[] numbers)
        {
            int maxNum = numbers.OrderByDescending(x => x).FirstOrDefault();

            return maxNum;
        }

        static int GetNumberCount(int number, int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (number == numbers[i])
                {
                    count++;
                }
            }

            return count;
        }
    }
}
