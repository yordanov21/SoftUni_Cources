using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Revision")
                {
                    break;
                }

                var line = input.Split(", ");
                string shop = line[0];
                string product = line[1];
                double price = double.Parse(line[2]);

               
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }

                shops[shop].Add(product, price);
           
            }

            var orderedShops = shops.OrderBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var shop in orderedShops)
            {
                string curentShop = shop.Key;
                Console.WriteLine(curentShop+"->");
                foreach (var product in shop.Value)
                {
                    string currentProduct = product.Key;
                    double price = product.Value;
                    Console.WriteLine($"Product: {currentProduct}, Price: {price}");
                }
            }
        }
    }
}
