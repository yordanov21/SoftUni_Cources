using System;

namespace _09._House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int startCount = 1;
            if (n % 2 == 0)
            {
                startCount++;
            }
            for (int row = 0; row < (n + 1) / 2; row++)
            {
                int dashCount = (n - startCount) / 2;
                Console.WriteLine(new string('-', dashCount) + new string('*', startCount) + new string('-', dashCount));
                startCount += 2;
            }
            for (int row = 0; row < n / 2; row++)
            {
                Console.WriteLine('|' + new string('*', n - 2) + '|');
            }
        }
    }
}
