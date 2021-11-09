using System;
using System.Linq;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray().Sum());
  
        }
    }
}
