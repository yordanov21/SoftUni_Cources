using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double PriceBaklava = double.Parse(Console.ReadLine());
            double PriceMufins = double.Parse(Console.ReadLine());
            double KGshtolen = double.Parse(Console.ReadLine());
            double KGbonboni = double.Parse(Console.ReadLine());
            double KGbiskets = double.Parse(Console.ReadLine());

            double PriceShtolenzaKG = PriceBaklava + PriceBaklava * 0.60;
            double PriceShtolen = KGshtolen * PriceShtolenzaKG;
            double PriceBonbinizaKG = PriceMufins + 0.80 * PriceMufins;
            double Pricebinbini = KGbonboni * PriceBonbinizaKG;
            double PriceBisketskg = 7.50;
            double PriceBiskets = PriceBisketskg * KGbiskets;
            double sum = PriceShtolen + Pricebinbini + PriceBiskets;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
