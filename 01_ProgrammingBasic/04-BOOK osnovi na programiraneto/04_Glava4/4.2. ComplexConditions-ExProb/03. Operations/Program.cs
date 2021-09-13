using System;

namespace _03._Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            if (symbol == "+")
            {
                int rezult = N1 + N2;
                if (rezult % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - odd");
                }
            }
            else if (symbol == "-")
            {
                int rezult = N1 - N2;
                if (rezult % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - odd");
                }
            }
            else if (symbol == "*")
            {
                int rezult = N1 * N2;
                if (rezult % 2 == 0)
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - even");
                }
                else
                {
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult} - odd");
                }
            }
            else if (symbol == "/")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    double rezult = (double)N1 / N2;
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult:f2}");
                }
            }
            else if (symbol == "%")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    int rezult = N1 % N2;
                    Console.WriteLine($"{N1} {symbol} {N2} = {rezult}");
                }
                
            }
        }
    }
}
