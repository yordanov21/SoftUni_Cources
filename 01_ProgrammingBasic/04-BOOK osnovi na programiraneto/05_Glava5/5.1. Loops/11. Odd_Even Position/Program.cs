using System;

namespace _11._Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double oddSum = 0;        
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= N; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (evenMax < num)
                    {
                        evenMax = num;
                    }
                    if (evenMin > num)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (oddMax < num)
                    {
                        oddMax = num;
                    }
                    if (oddMin > num)
                    {
                        oddMin = num;
                    }
                }
            }

            Console.WriteLine("OddSum=" + oddSum);
            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No");
            }
            else
            {
                Console.WriteLine("OddMin="+oddMin);
            }
            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No");
            }
            else
            {
                Console.WriteLine("OddMax=" + oddMax);
            }
            Console.WriteLine("EvenSum=" + evenSum);
            if (evenMin== double.MaxValue)
            {
                Console.WriteLine("EvenMin=No");
            }
            else
            {
                Console.WriteLine("EvenMin=" + evenMin);
            }
            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine("EvenMax=" + evenMax);
            }

        }
    }
}
