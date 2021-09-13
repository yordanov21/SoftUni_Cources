using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWhiskey = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());
            double priceRakia = 0.5 * priceWhiskey;
            double priceWine = priceRakia - (0.4 * priceRakia);
            double priceBeer = priceRakia - (0.8 * priceRakia);
            double AllPrice = beer * priceBeer + wine * priceWine + rakia * priceRakia + whiskey * priceWhiskey;

            Console.WriteLine($"{AllPrice:f2}");


        }
    }
}
