using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> repeatedNumbers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    if (!repeatedNumbers.ContainsKey(number))
                    {
                        repeatedNumbers[number] = 1;
                    }
                    repeatedNumbers[number] += 1;
                }
                numbers.Add(number);

            }
          
            foreach (var num in repeatedNumbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }              
            }
        }
    }
}
