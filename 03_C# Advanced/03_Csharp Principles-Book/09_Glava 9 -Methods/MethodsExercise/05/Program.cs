using System;
using System.Linq;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            int positionToCheck = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckNumber(positionToCheck,numbers));

            Console.WriteLine(GetNumber(numbers));
        }

        static bool CheckNumber(int num, int[] numbers)
        {
            int currentNum = numbers[num];
            if (currentNum > numbers[num - 1] || currentNum > numbers[num + 1])
            {
                return true;
            }

            return false;
        }

        static int GetNumber( int[] numbers)
        {

            for (int i = 1; i < numbers.Length-1; i++)
            {
                if ( numbers[i]>numbers[i-1]&&numbers[i]>numbers[i+1])
                {
                    return numbers[i];
                }
            }

            return -1;
        }
    }
}
