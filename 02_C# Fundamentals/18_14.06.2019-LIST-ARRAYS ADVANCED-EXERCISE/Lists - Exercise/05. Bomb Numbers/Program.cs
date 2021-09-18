using System;
using System.Linq;
using System.Collections.Generic;


namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            int[] bombs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (bombs[0] == numbers[i])
                {
                    numbers.RemoveAt(i);
                  
                }

            }
            Console.WriteLine(string.Join(" ",numbers));
            Console.WriteLine(numbers.Sum());


        }
    }
}
