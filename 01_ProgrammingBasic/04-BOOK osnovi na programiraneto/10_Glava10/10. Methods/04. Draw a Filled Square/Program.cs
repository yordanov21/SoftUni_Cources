using System;

namespace _04._Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintFirstLine(n);
            PrintBody(n);
            PrintLastLine(n);
        }

        static void PrintFirstLine(int n)
        {
            Console.Write(new string('-',n*2));
            Console.WriteLine();
        }
        static void PrintLastLine(int n)
        {
            Console.Write(new string('-', n * 2));
            Console.WriteLine();
        }

        static void PrintBody(int n)
        {
            for (int i = 1; i < n-1; i++)
            {
                Console.Write('-');
                for (int j = 1; j < n; j++)
                {
                    Console.Write(@"\/");
                }
                Console.Write('-');
                Console.WriteLine();
            }
        }
    }
}
