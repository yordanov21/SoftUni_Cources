using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int table = int.Parse(Console.ReadLine());
            double leight = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double areaCover = (leight+0.6) * (width+0.6);
            double areaCare = (leight / 2) * (leight / 2);
            double priceCover = 7;
            double priceCare = 9;
            double PriceUSD = (table * areaCover * priceCover + table * areaCare * priceCare);
            double PriceBGN = PriceUSD * 1.85;

            Console.WriteLine("{0:F2} USD", PriceUSD);
            Console.WriteLine("{0:F2} BGN", PriceBGN);


        }
    }
}
