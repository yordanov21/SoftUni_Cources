using System;

namespace _08._Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var factoriel = 1;

            do
            {
                factoriel = factoriel * n;
                n--;
            }
            while (n > 1);
            {
                Console.WriteLine(factoriel);
            }
        }
    }
}
