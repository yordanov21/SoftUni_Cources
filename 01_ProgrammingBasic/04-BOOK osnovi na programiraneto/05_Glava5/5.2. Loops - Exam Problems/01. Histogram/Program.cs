using System;

namespace _01._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            
            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num < 200)
                {
                    p1++;
                }
                else if (num >= 200 && num < 400)
                {
                    p2++;
                }
                else if (num >= 400 && num < 600)
                {
                    p3++;
                }
                else if (num >= 600 && num < 800)
                {
                    p4++;
                }
                else if (num >= 800 )
                {
                    p5++;
                }
            }

            double p1percent = p1 / N * 100.00;
            double p2percent = p2 / N * 100.00;
            double p3percent = p3 / N * 100.00;
            double p4percent = p4 / N * 100.00;
            double p5percent = p5 / N * 100.00;

            Console.WriteLine($"{p1percent:f2}%");
            Console.WriteLine($"{p2percent:f2}%");
            Console.WriteLine($"{p3percent:f2}%");
            Console.WriteLine($"{p4percent:f2}%");
            Console.WriteLine($"{p5percent:f2}%");
        }
    }
}
