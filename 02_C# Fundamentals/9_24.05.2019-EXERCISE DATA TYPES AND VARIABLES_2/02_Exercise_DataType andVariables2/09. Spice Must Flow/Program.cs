using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yieldStart = int.Parse(Console.ReadLine());
            int yield = 0;
            int totalYield = 0;
            int days = 0;
            if (yieldStart >= 100)
            {
                while (yieldStart >= 100)
                {
                    days++;
                    yield = yieldStart - 26;
                    totalYield += yield;
                    yieldStart -= 10;

                }
                totalYield -= 26;
                Console.WriteLine(days);
                Console.WriteLine(totalYield);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(totalYield);
            }
            
        }
    }
}
