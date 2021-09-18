using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static double CalculatingFactoriel(double factorialNumber)
        {
            double factorialResult = 1;
            for (int i = 1; i <= factorialNumber; i++)
            {
                factorialResult = factorialResult * i;
            }
            return factorialResult;
        }

        static void PrintResult(double a, double b)
        {
            double divideResults = a / b;
            Console.WriteLine($"{divideResults:F2}");
        }

        static void Main(string[] args)
        {
            double firstInteger = double.Parse(Console.ReadLine());
            double secondInteger = double.Parse(Console.ReadLine());
            double firstFactoriel = CalculatingFactoriel(firstInteger);
            double secondFactoriel = CalculatingFactoriel(secondInteger);
            PrintResult(firstFactoriel, secondFactoriel);
        }
    }
}
