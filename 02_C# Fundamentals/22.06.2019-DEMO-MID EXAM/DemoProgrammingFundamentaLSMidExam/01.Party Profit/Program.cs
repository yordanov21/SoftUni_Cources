using System;

namespace _01.Party_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int partyDays = int.Parse(Console.ReadLine());
            int partyProfit = 0;
            for (int i = 1; i <= partyDays; i++)
            {
                if (i % 10 == 0)
                {
                    partySize -= 2;
                }
                if (i % 15 == 0)
                {
                    partySize += 5;
                }
                partyProfit +=  50 - 2 * partySize;
                if (i % 3 == 0)
                {
                    partyProfit -= 3 * partySize;
                }
                if (i % 5 == 0)
                {
                    partyProfit += 20 * partySize;
                }
                if (i % 15 == 0)
                {
                    partyProfit -= 2 * partySize;
                }
    
            }
            Console.WriteLine($"{partySize} companions received {partyProfit/partySize} coins each.");

        }
    }
}
