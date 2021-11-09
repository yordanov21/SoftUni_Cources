using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine()
                    .Split();
                foreach (var element in input)
                {
                    elements.Add(element);
                }
            }

            var sortedElements = elements.OrderBy(x=>x);
            Console.WriteLine(string.Join(" ",sortedElements));
        }
    }
}
