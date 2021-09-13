using System;

namespace _06._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            for (int i = 0; i < num; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < min)
                {
                    min = number;
                }
            }

            Console.WriteLine(min);
        }
    }
}
