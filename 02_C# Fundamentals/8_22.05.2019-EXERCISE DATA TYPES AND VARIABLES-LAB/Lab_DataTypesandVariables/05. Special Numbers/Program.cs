using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int digit = 0;

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;


                digit = i % 10;
                sum += digit;
                digit = i / 10;
               
                if (digit != 0)
                {
                    digit = digit % 10;
                    sum += digit;
                    digit = digit / 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
