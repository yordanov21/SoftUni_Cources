using System;

namespace _06._Sums_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            if (num1 + num2 == num3)
            {
                Console.WriteLine($"{Math.Min(num1,num2)} + {Math.Max(num1, num2)} = {num3}");
            }
            else if(num1 + num3 == num2)
            {
                Console.WriteLine($"{Math.Min(num1, num3)} + {Math.Max(num1, num3)} = {num2}");
            }
            else if (num2 + num3 == num1)
            {
                Console.WriteLine($"{Math.Min(num3, num2)} + {Math.Max(num3, num2)} = {num1}");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
