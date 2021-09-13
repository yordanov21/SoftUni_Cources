using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;
            int counter5 = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            for (int i=0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    counter1++;
                }
                else if(number>=200 && number < 400)
                {
                    counter2++;
                }
                else if (number >= 400 && number < 600)
                {
                    counter3++;
                }
                else if (number >= 600 && number < 800)
                {
                    counter4++;
                }
                else if (number >= 800)
                {
                    counter5++;
                }
            }
            p1 = (double)counter1 / n * 100;
            p2 = (double)counter2 / n * 100;
            p3 = (double)counter3 / n * 100;
            p4 = (double)counter4 / n * 100;
            p5 = (double)counter5 / n * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
