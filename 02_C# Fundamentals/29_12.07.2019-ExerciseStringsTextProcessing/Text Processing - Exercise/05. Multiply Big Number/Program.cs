using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            BigInteger result = number * number2;
            Console.WriteLine(result);

        }
    }
}
