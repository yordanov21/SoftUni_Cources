using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = MinNumber;
            var input=Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(minNum(input));
        }

        public static int MinNumber(int[] num)
        {
            int minNumber = num.Min();
            return minNumber;
        }
    }
}
