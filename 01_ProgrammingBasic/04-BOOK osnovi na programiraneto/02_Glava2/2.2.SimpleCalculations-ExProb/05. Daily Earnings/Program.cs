using System;

namespace _05._Daily_Earnings
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double moneyPerDay = double.Parse(Console.ReadLine());
            double coureUSDtoLeva = double.Parse(Console.ReadLine());

            double monthSelary = days * moneyPerDay;
            double yearSelary = monthSelary * 12 + 2.5 * monthSelary;
            double taxs = 0.25 * yearSelary;
            double yearMoneyAfterTaxs = yearSelary - taxs;
            double yearMoneyInBGN = yearMoneyAfterTaxs *coureUSDtoLeva;

            double dayMoney = yearMoneyInBGN / 365;
            Console.WriteLine(Math.Round( dayMoney,2));
        }
    }
}
