using System;

namespace _05._Orders
{
    class Program
    {
        static void Order(int productQuantity, double price)
        {
            Console.WriteLine( $"{ productQuantity* price:f2}");

        }
        static void Main(string[] args)
        {
            string productName = Console.ReadLine();
            int procuctQuantity = int.Parse(Console.ReadLine());
            double coffeePrice = 1.50;
            double waterPrice = 1.00;
            double cokePrice = 1.40;
            double snacksPrice = 2.00;
            double price = 0.00;
            switch (productName)
            {
                case "coffee":
                    price = coffeePrice;
                    Order(procuctQuantity, price);
                    break;
                case "water":
                     price = waterPrice;
                    Order(procuctQuantity, price);
                    break;
                case "coke":
                    price = cokePrice;
                    Order(procuctQuantity, price);
                    break;
                case "snacks":
                     price = snacksPrice;
                    Order(procuctQuantity, price);
                    break;
            }
        }
    }
}
