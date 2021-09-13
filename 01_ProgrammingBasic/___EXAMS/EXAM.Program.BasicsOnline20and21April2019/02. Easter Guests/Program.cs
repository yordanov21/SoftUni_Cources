using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int GuestNUM = int.Parse(Console.ReadLine());
            int bujet = int.Parse(Console.ReadLine());
            double PriceOneEasterbread = 4.0;
            double priceOneEggs = 0.45;

            double EasterBread = Math.Ceiling(GuestNUM / 3.00);
            double eggs = GuestNUM * 2.0;

            double PriceEasterbread = EasterBread * PriceOneEasterbread;
            double PriceEggs = priceOneEggs * eggs;
            double AllPrice = PriceEggs + PriceEasterbread;
            double difference = Math.Abs(bujet - AllPrice);

            if (bujet >= AllPrice)
            {
                Console.WriteLine($"Lyubo bought {EasterBread} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {difference:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {difference:f2} lv. more.");
            }
        }
    }
}
