using System;

namespace _07._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n = ");
            int N = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRigth = 0;

            for (int i = 0; i < N; i++)
            {
                int n1left = int.Parse(Console.ReadLine());
                sumLeft += n1left;
            }
            for (int i = 0; i < N; i++)
            {
                int n1rigth = int.Parse(Console.ReadLine());
                sumRigth += n1rigth;
            }

            if (sumLeft == sumRigth)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }
            else
            {
                int difference = Math.Abs(sumLeft - sumRigth);
                Console.WriteLine($"No, diff = {difference}");
            }
        }
    }
}
