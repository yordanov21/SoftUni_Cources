using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string FanName = Console.ReadLine();
            double bujet = double.Parse(Console.ReadLine());
            int beers = int.Parse(Console.ReadLine());
            int chips = int.Parse(Console.ReadLine());

            double beerPrice = 1.20 * beers;
            double OneChipsPrice = 0.45 * beerPrice;
            double chipsPrice = Math.Ceiling(chips * OneChipsPrice);
            double sum = chipsPrice + beerPrice;
            double difference = Math.Abs(bujet - sum);
            if (sum <= bujet)
            {
                Console.WriteLine($"{FanName} bought a snack and has {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{FanName} needs {difference:f2} more leva!");
            }

        }
    }
}
