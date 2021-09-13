using System;

namespace _05._Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int p2 = 0;
            int p3 = 0;
            int p4 = 0;

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 4 == 0)
                {
                    p4++;
                }
                if (num % 3 == 0)
                {
                    p3++;
                }
                if (num % 2 == 0)
                {
                    p2++;
                }

            }

            double p2percent = (double)p2 / N * 100.00;
            double p3percent = (double)p3 / N * 100.00;
            double p4percent = (double)p4 / N * 100.00;

            Console.WriteLine($"{p2percent:f2}%");
            Console.WriteLine($"{p3percent:f2}%");
            Console.WriteLine($"{p4percent:f2}%");
        }
    }
}
