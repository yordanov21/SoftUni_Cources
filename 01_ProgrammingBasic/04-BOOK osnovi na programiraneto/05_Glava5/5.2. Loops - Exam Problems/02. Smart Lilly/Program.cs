using System;

namespace _02._Smart_Lilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int LillyAge = int.Parse(Console.ReadLine());
            double priceWashingMashine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            double savedMoney = 0;
            int toysCount = 0;
            for (int i = 1; i <= LillyAge; i++)
            {
                if (i % 2 != 0)
                {
                    toysCount++;
                }
                else
                {
                    savedMoney += i * 5;
                    savedMoney -= 1;

                }
            }
            savedMoney = savedMoney + toysCount * toyPrice;
            if (savedMoney >= priceWashingMashine)
            {
                double diff = savedMoney - priceWashingMashine;         
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                double diff = priceWashingMashine - savedMoney;
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
