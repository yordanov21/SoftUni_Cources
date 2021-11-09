using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbersArr = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            int number = int.Parse(Console.ReadLine());

            Predicate<int> filter = x => x % number != 0;
            Func<int, bool> filterFunc = x => filter(x);

            numbersArr = numbersArr.Where(filterFunc).Reverse();

            Console.WriteLine(string.Join(" ", numbersArr));
        }
    }
}
