using System;

namespace _03._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintUpTriangle(n);
            PrintLine(1, n);
            PrintDownTriangle(n);
        }
        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");             
            }
            Console.WriteLine();
        
        }
        static void PrintUpTriangle(int n)
        {
            for (int i = 0; i < n; i++)
            {
                PrintLine(1, i);
            }
        }
        static void PrintDownTriangle(int n)
        {
            for (int i = n-1; i > 0; i--)
            {
                PrintLine(1, i);
            }
        }
    }
}
