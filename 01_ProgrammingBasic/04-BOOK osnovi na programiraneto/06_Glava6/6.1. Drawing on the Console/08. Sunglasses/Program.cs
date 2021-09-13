using System;

namespace _08._Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('*', n * 2));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', n * 2));
            Console.WriteLine();
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("*");
                for (int j = 0; j < n*2 - 2; j++)
                {
                    Console.Write("/");
                }
                Console.Write("*");
                if (i == (n - 1) / 2 - 1)
                {
                    Console.Write(new string('|', n));
                }
                else
                {
                    Console.Write(new string(' ', n));
                }
                Console.Write("*");
                for (int j = 0; j < n*2 - 2; j++)
                {
                    Console.Write("/");
                }
                Console.Write("*");
                Console.WriteLine();
            }
            Console.Write(new string('*', n * 2));
            Console.Write(new string(' ', n));
            Console.Write(new string('*', n * 2));
        }
    }
}
