using System;

namespace _10._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
           int N=int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNum = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (maxNum < num)
                {
                    maxNum = num;
                }
            }
            int sumNumbers = sum - maxNum;
            if (sumNumbers == maxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = "+maxNum);
            }
            else
            {              
                int diff = Math.Abs(maxNum - sumNumbers);
                Console.WriteLine("No");
                Console.WriteLine("Diff = "+diff);
            }
        }
    }
}
