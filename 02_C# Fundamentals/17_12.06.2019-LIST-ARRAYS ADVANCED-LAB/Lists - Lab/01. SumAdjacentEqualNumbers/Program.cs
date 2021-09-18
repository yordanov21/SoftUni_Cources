using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
         
           List <double> numbers = Console.ReadLine()
               .Split()
               .Select(double.Parse)
               .ToList();

           for (int i = 1; i < numbers.Count; i++)
           {
               if (numbers[i] == numbers[i - 1])
               {
                   numbers[i] += numbers[i - 1];
                   numbers.RemoveAt(i-1);
                    i = 0;
               }
           
   
           }
           Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
