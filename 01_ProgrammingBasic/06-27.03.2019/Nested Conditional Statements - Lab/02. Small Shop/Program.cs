using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;

            double sofiaCoffee = 0.50;
            double sofiaWater = 0.80;
            double sofiaBeer = 1.20;
            double sofiaSweets = 1.45;
            double sofiaPeanuts = 1.60;

            double plovdivCoffee = 0.40;
            double plovdivWater = 0.70;
            double plovdivBeer = 1.15;
            double plovdivSweets = 1.30;
            double plovdivPeanuts = 1.50;

            double varnaCoffee = 0.45;
            double varnaWater = 0.70;
            double varnaBeer = 1.10;
            double varnaSweets = 1.35;
            double varnaPeanuts = 1.55;

            if (city == "Sofia")
            {
                if (productName == "coffee")
                {
                    price = quantity * sofiaCoffee;
                    Console.WriteLine(price);
                }
                else if (productName == "water")
                {
                    price = quantity * sofiaWater;
                    Console.WriteLine(price);
                }
                else if (productName == "beer")
                {
                    price = quantity * sofiaBeer;
                    Console.WriteLine(price);
                }
                else if (productName == "sweets")
                {
                    price = quantity * sofiaSweets;
                    Console.WriteLine(price);
                }
                else if (productName == "peanuts")
                {
                    price = quantity * sofiaPeanuts;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Plovdiv")
            {
                if (productName == "coffee")
                {
                    price = quantity * plovdivCoffee;
                    Console.WriteLine(price);
                }
                else if (productName == "water")
                {
                    price = quantity * plovdivWater;
                    Console.WriteLine(price);
                }
                else if (productName == "beer")
                {
                    price = quantity * plovdivBeer;
                    Console.WriteLine(price);
                }
                else if (productName == "sweets")
                {
                    price = quantity * plovdivSweets;
                    Console.WriteLine(price);
                }
                else if (productName == "peanuts")
                {
                    price = quantity * plovdivPeanuts;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Varna")
            {
                if (productName == "coffee")
                {
                    price = quantity * varnaCoffee;
                    Console.WriteLine(price);
                }
                else if (productName == "water")
                {
                    price = quantity * varnaWater;
                    Console.WriteLine(price);
                }
                else if (productName == "beer")
                {
                    price = quantity * varnaBeer;
                    Console.WriteLine(price);
                }
                else if (productName == "sweets")
                {
                    price = quantity * varnaSweets;
                    Console.WriteLine(price);
                }
                else if (productName == "peanuts")
                {
                    price = quantity * varnaPeanuts;
                    Console.WriteLine(price);
                }
            }
           
        }
    }
}
