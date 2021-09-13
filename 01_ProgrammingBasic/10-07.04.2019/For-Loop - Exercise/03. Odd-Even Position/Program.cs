using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;                           //nechetni
            double oddmin = double.MaxValue;
            double oddmax = double.MinValue;

            double evenSum = 0;                         //chetni 
            double evenmin = double.MaxValue;
            double evenmax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double number=double.Parse(Console.ReadLine());
              
                if (i % 2 == 0)
                {
                    evenSum += number;
                    if (number > evenmax)
                    {
                        evenmax = number;
                    }
                    if (number < evenmin)
                    {
                        evenmin = number;
                    }
                }
                else
                {
                    oddSum += number;
                    if (number > oddmax)
                    {
                        oddmax = number;
                    }
                    if (number < oddmin)
                    {
                       oddmin = number;
                    }
                }

            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddmin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddmin:f2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
            if (oddmax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddmax:f2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }          
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenmin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenmin:f2},");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (evenmax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenmax:f2}");
            }
            else
            {
                Console.WriteLine($"EvenMax=No");

            }
        }
    }
}
