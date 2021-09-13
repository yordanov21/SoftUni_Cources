using System;

namespace _08._Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countCurrentLongest = 0;
            int countLongest = 0;
            int aPrev = 0;
            int a = 0;

            for (int i = 1; i <= n; i++)
            {
                a = int.Parse(Console.ReadLine());
                if (a > aPrev)
                {
                    countCurrentLongest++;
                }
                else
                {
                    countCurrentLongest = 1;
                }

                if (countLongest < countCurrentLongest)
                {
                    countLongest = countCurrentLongest;
                }

                aPrev = a;
            }

            Console.WriteLine(countLongest);
        }
    }
}
