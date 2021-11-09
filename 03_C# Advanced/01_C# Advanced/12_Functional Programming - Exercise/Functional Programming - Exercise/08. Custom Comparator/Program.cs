using System;
using System.Linq;
using System.Collections.Generic;


namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Func<int, int, int> myCustomComparer = (a, b) =>
            {
                if (a % 2 == 0 && b % 2 == 0)
                {
                    if (a < b)
                    {
                        return -1;
                    }
                    if (a > b)
                    {
                        return 1;
                    }

                    return 0;
                }

                if (a % 2 != 0 && b % 2 != 0)
                {
                    if (a < b)
                    {
                        return -1;
                    }
                    if (a > b)
                    {
                        return 1;
                    }

                    return 0;
                }

                if (a % 2 == 0)
                {
                    return -1;
                }

                if (a % 2 != 0)
                {
                    return 1;
                }

                return 0;
            };

            Array.Sort(input, new Comparison<int>(myCustomComparer));

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
