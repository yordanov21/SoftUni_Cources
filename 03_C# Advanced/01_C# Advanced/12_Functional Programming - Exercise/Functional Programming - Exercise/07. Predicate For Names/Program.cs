using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var namesArr = Console.ReadLine()
                  .Split();
                 
            Predicate<string> filter = x => x.Length <= number;
            Func<string, bool> filterFunc = x => filter(x);

            namesArr = namesArr.Where(filterFunc).ToArray();

            foreach (var name in namesArr)
            {
                Console.WriteLine(name);
               
            }
           
        }
    }
}
