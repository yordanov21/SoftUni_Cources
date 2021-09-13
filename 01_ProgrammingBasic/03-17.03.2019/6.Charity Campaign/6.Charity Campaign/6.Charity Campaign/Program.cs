using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int confectioner = int.Parse(Console.ReadLine());
            int cake = int.Parse(Console.ReadLine());
            int wafer = int.Parse(Console.ReadLine());
            int pancake = int.Parse(Console.ReadLine());
            double priceCake = 45;
            double priceWafer = 5.8;
            double pricePancake = 3.2;
            double sumCake = cake * priceCake;
            double sumWafer = wafer * priceWafer;
            double sumPancake = pancake * pricePancake;
            double sumDay = (sumCake + sumWafer + sumPancake)*confectioner;
            double sumALL = sumDay * days;
            double sumProducts = sumALL * 1.0/8;
            double sumLAST = sumALL-sumProducts;
            
            Console.WriteLine($"{sumLAST:F2}");




        }
    }
}
