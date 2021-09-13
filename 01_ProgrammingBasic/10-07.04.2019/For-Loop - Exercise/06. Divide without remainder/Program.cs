using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;


            double p1 = 0;
            double p2 = 0;
            double p3 = 0;


            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number%2==0)
                {
                    counter1++;
                }
                if (number%3==0)
                {
                    counter2++;
                }
                if (number%4==0)
                {
                    counter3++;
                }
             
            }
            p1 = (double)counter1 / n * 100;
            p2 = (double)counter2 / n * 100;
            p3 = (double)counter3 / n * 100;

            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");

        }
    }
}
