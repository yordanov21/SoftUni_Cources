using System;
using System.Numerics;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            BigInteger f = 1;
            for (int i = 2; i <= N; i++)     
                f *= i;

            Console.WriteLine(f);
        }
    }
}
