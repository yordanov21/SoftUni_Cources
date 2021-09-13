using System;

namespace _04._Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitCoins = int.Parse(Console.ReadLine());
            double yuans = double.Parse(Console.ReadLine());
            double comishion = double.Parse(Console.ReadLine());

            double moneyInLeva = bitCoins * 1168 + yuans * 0.15 * 1.76;
            double comisionMoney = moneyInLeva * comishion / 100;

            double moneyInEUR =( moneyInLeva-comisionMoney) / 1.95;
          
            Console.WriteLine(moneyInEUR);

        }
    }
}
