using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char Operator = char.Parse(Console.ReadLine());

            if (Operator == '+')
            {
                double sum = N1 + N2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - odd");

                }
            }
            else if (Operator == '-')
            {
                double sum = N1 - N2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - odd");

                }
            }
            else if (Operator == '*')
            {
                double sum = N1 * N2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {Operator} {N2} = {sum} - odd");

                }
            }
            else if (Operator == '/')
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    double sum = N1 / N2;
                    Console.WriteLine($"{ N1} / { N2} = {sum:f2}");
                }
            }
            else if (Operator == '%')
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    double sum = N1 % N2;
                    Console.WriteLine($"{ N1} % { N2} = {sum}");
                }
            }
        }
    }
}

