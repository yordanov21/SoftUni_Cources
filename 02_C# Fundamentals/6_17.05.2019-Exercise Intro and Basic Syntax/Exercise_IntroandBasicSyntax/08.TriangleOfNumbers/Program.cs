using System;

namespace _08.TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num = int.Parse(Console.ReadLine());

            if (Num > 0 && Num < 21)
            {
                for (int i = 1; i <= Num; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.WriteLine();
                }
             
            }

        }
    }
}
