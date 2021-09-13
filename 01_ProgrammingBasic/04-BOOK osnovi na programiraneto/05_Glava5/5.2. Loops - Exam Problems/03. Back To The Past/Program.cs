using System;

namespace _03._Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double legacy = double.Parse(Console.ReadLine());
            int yearEnd = int.Parse(Console.ReadLine());
            int IvanchoYears = 18;
           
            double moneyForSpend = legacy;
            for (int i = 1800; i <= yearEnd; i++)
            {
                if (i % 2 == 0)
                {
                    moneyForSpend -= 12000;
                   
                }
                else
                {
                   
                    moneyForSpend -= 12000 + 50 * IvanchoYears;
                }
                IvanchoYears++;
            }

            if (moneyForSpend >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyForSpend:f2} dollars left.");
            }
            else
            {
                moneyForSpend *= -1;
                Console.WriteLine($"He will need {moneyForSpend:f2} dollars to survive.");
            }
        }
    }
}
