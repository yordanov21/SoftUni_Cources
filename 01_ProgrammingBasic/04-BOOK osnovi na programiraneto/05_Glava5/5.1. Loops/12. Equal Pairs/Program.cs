using System;

namespace _12._Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            double oldSum = 0;
            double difference = 0;

            for (int i = 0; i < n; i++)
            {
                double num1 = double.Parse(Console.ReadLine());
                double num2 = double.Parse(Console.ReadLine());
                sum = num1 + num2;
                difference = Math.Max(sum, oldSum) - Math.Min(sum, oldSum);
                oldSum = sum;
            }

            if (n == 1)
            {
                Console.WriteLine("Yes, value={0}", difference);
            }
            else
            {
                if (difference == 0)
                {
                    Console.WriteLine("Yes, value={0}", sum);
                }
                else
                {
                    Console.WriteLine("No, maxdiff={0}", difference);
                }
            }
        }
    }
}
