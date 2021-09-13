using System;

namespace _09._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sum = 0;
            do
            {
                int ostatuk = n % 10;
                sum += ostatuk;
                n = n / 10;
            }
            while (n > 0);
           
            Console.WriteLine("Sum of digits: {0}", sum);
        }
    }
}
