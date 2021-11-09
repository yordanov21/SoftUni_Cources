using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;
          
            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            List<int> numbers = new List<int>();
            int startNumber = input[0];
            int endNumber = input[1];

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            string numberType = Console.ReadLine();
            if (numberType == "even")
            {
                foreach ( var number in numbers)
                {
                    if (isEvenPredicate(number))
                    {
                        Console.Write(number+" ");
                    }
                }
            }
            else if(numberType=="odd")
            {
                foreach (var number in numbers)
                {
                    if (!isEvenPredicate(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
        }
    }
}
