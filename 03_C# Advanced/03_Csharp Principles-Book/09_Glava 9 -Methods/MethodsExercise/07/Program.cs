using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            ReverseNumber(num);
        }

        static void ReverseNumber(int num)
        {
            while (num != 0)
            {
                Console.Write(num%10);
                num = num / 10;
            }
            
        }
    }
}
