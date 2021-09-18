using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] arrFibonacci = new int[number];
            arrFibonacci[0] = 1;

            if (number <= 1)
            {
                Console.WriteLine("1");
                return;

            }

            else if (number > 1 && number <= 50)
            {
                arrFibonacci[1] = 1;

                for (int i = 2; i < arrFibonacci.Length; i++)
                {
                    arrFibonacci[i] = arrFibonacci[i - 1] + arrFibonacci[i - 2];

                }

                Console.WriteLine(arrFibonacci[arrFibonacci.Length - 1]);
            }

            else
            {
                return;

            }

        }
    }
}
