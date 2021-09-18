using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum1 = num1 + num2;
            int sum2 = sum1 - num3;
            Console.WriteLine(sum2);
        }
    }
}
