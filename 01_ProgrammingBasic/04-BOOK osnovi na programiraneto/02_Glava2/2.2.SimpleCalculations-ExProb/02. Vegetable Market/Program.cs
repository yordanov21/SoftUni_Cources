using System;

namespace _02._Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int kgVegetables = int.Parse(Console.ReadLine());
            int kgFruits = int.Parse(Console.ReadLine());

            double vegeCoast = priceVegetables * kgVegetables;
            double fruitsCoast = priceFruits * kgFruits;

            double allCoast = (vegeCoast + fruitsCoast);
            double priceInEUR = allCoast / 1.94;
            Console.WriteLine(priceInEUR);
        }
    }
}
