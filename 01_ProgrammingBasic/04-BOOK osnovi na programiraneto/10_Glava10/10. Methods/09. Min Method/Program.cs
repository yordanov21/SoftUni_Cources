using System;

namespace _09._Min_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            var min = GetMin(GetMin(num1, num2), num3);

            Console.WriteLine(min);
        }

        static int GetMin(int a, int b)
        {
            return Math.Min(a, b);
        }
    }
}
