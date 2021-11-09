using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Console.ReadLine()
                .Split()
                .FirstOrDefault(x => x.ToCharArray()
                     .Select(y => (int)y)
                     .Sum() >= number));
        }
    }
}
