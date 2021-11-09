using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        public static void Main()
        {
            Action<string> print = item => Console.WriteLine(item);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);

          
        }
    }
}
