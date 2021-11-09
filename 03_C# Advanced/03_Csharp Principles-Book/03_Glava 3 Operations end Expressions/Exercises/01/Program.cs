using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {


            int num = int.Parse(Console.ReadLine());
            PrintEvenOdd(num);
            Console.WriteLine(CheckDivisionBy5and7(num));
            Console.WriteLine(CheckForSeven(num));
            Console.WriteLine(CheckThirdBit(num));
            Console.WriteLine(GetBit(num));
        }

        static void PrintEvenOdd(int num)
        {
            if (num % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }

        static bool CheckDivisionBy5and7(int num)
        {
            if (num % 5 == 0 && num % 7 == 0)
            {
                return true;
            }

            return false;
        }

        static bool CheckForSeven(int num)
        {
            int number = num / 100;
            int checkNumber = number % 10;
            if (checkNumber == 7)
            {
                return true;
            }
            return false;
        }

        static bool CheckThirdBit(int num)
        {          
            return   (num & 8) != 0;
        }

        static int GetBit(int num)
        {
            
            int p = 6;
            int i = 1; // 00000001
            int mask = i << p; // Move the 1st bit left by p positions
                               // If i & mask are positive then the p-th bit of n is 1
           return (num & mask) != 0 ? 1 : 0;
        }
    }
}
