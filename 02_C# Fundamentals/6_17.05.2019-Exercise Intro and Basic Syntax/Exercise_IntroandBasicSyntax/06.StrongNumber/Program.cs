using System;

namespace _06.StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int checkNum = inputNum;
            int factorialSum = 0;

            while (checkNum != 0)
            {
                int result = checkNum % 10;
                checkNum /= 10;

                int factorial = 1;
                for (int i = 1; i <= result; i++)
                {
                    factorial *= i;
                }
                factorialSum += factorial;
            }

            if (factorialSum == inputNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
