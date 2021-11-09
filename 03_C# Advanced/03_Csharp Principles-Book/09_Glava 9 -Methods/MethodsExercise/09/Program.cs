using System;
using System.Linq;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(GetBigestNumber(numbersArray));
            Console.WriteLine(GetBigestNumberInRange(numbersArray,2,10));
        }

        static int GetBigestNumber(int[] numbersArray)
        {
            int bigestNumber = numbersArray.OrderByDescending(x => x).FirstOrDefault();

            return bigestNumber;
        }

        static int GetBigestNumberInRange(int[] numbersArray,int n1, int n2)
        {
            var arrayInRange = new int[n2-n1];
            int count = 0;
            for (int i = n1; i < numbersArray[n2]-1; i++)
            {
                arrayInRange[count] = numbersArray[i];
                count++;
            }
            int bigestNumber = arrayInRange.OrderByDescending(x => x).FirstOrDefault();

            return bigestNumber;
        }
    }
}
