using System;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            Print();
        }

        static void Print()
        {
            int result = 1;
            Console.WriteLine(result);
            for (int i = 2; i <=100; i++)
            {
                result = result * i;
                Console.WriteLine(result);
            }

        }
    }
}
