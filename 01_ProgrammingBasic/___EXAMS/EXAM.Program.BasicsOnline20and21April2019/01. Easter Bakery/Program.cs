using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flowerPriceKG = double.Parse(Console.ReadLine());
            double KGflower = double.Parse(Console.ReadLine());
            double KGsugar = double.Parse(Console.ReadLine());
            double eggsNUM = double.Parse(Console.ReadLine());
            double leavenPAG = double.Parse(Console.ReadLine());

            double sugarPriceKG = flowerPriceKG * 0.75;
            double eggsPriceNUM = flowerPriceKG * 1.10;
            double leavenPricePAG = sugarPriceKG * 0.2;

            double PriceFlower = KGflower * flowerPriceKG;
            double PriceSugar = KGsugar * sugarPriceKG;
            double PriceEggs = eggsNUM * eggsPriceNUM;
            double PriceLeaven = leavenPAG * leavenPricePAG;

            double SumAll = PriceFlower + PriceSugar + PriceEggs + PriceLeaven;

            Console.WriteLine($"{SumAll:f2}");
        }
    }
}
