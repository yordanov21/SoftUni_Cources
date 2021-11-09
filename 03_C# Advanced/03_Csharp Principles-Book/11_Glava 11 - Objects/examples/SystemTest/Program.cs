using System;

namespace SystemTest
{
    class Program
    {
        static void Main()
        {
            int sum = 0;
            int startTime = Environment.TickCount;

            for (int i = 0; i < 10000000; i++)
            {
                sum++;
            }

            int endTime = Environment.TickCount;

            Console.WriteLine($"The time elapsed id {(endTime-startTime)/1000.0} sec.");
        }
    }
}
