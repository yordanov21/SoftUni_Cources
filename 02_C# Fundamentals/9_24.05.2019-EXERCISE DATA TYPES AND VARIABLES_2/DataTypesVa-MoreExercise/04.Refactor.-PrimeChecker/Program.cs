using System;

namespace _04.Refactor._PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool checkPrime = true;
                string prime = "true";
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        checkPrime = false;
                        prime = "false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", i, prime);
            }

        }
    }
}
