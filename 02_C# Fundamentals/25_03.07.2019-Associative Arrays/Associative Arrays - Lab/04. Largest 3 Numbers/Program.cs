using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerArr = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            int counter = 0;
            int[] sorted = integerArr.OrderByDescending(x => x).ToArray();


            for (int i = 0; i < sorted.Length; i++)
            {

                if (counter < 3)
                {
                    Console.Write(sorted[i] + " ");
                    counter++;
                }
            }
        }
    }
}
