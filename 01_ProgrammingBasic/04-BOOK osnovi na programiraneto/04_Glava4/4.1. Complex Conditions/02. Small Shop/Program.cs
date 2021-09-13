using System;

namespace _02._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = Console.ReadLine();
            var city = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            if (city == "Sofia")
            {
                if (product == "coffee")
                {
                    var price = quantity * 0.5;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    var price = quantity * 0.8;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    var price = quantity * 1.2;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    var price = quantity * 1.45;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    var price = quantity * 1.6;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Plovdiv")
            {
                if (product == "coffee")
                {
                    var price = quantity * 0.4;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    var price = quantity * 0.7;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    var price = quantity * 1.15;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    var price = quantity * 1.30;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    var price = quantity * 1.5;
                    Console.WriteLine(price);
                }
            }
            else if (city == "Varna")
            {
                if (product == "coffee")
                {
                    var price = quantity * 0.45;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    var price = quantity * 0.7;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    var price = quantity * 1.1;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    var price = quantity * 1.35;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    var price = quantity * 1.55;
                    Console.WriteLine(price);
                }
            }
        }
    }
}
