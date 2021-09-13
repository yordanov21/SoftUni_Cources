using System;

namespace _08._Odd_Even_Sum
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("n = ");
            int N = int.Parse(Console.ReadLine());
            int sumOdd = 0;
            int sumEven = 0;

            for (int i = 1; i <= N; i++)
            {
                int n1 = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven += n1;
                }
                else
                {
                    sumOdd += n1;
                }
                
            }          
            if (sumOdd == sumEven)
            {
                Console.WriteLine($"Yes, sum = {sumOdd}");
            }
            else
            {
                int difference = Math.Abs(sumOdd - sumEven);
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
