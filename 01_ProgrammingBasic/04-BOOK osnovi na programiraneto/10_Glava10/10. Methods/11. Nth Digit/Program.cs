using System;

namespace _11._Nth_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNthDigit();
        }

        static void FindNthDigit()
        {
            int number = int.Parse(Console.ReadLine());
            int index = int.Parse(Console.ReadLine());
            int count = 0;
            while (true)
            {
                var digit = number % 10;
                count++;
                if (count == index)
                {
                    Console.WriteLine(digit);
                    break;
                }
                number = number / 10;
            }
        }
    }
}
