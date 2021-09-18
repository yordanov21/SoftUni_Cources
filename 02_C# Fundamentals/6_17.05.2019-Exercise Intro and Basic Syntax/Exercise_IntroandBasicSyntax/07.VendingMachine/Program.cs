using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.0;

            string input = Console.ReadLine();
            while (input != "Start")
            {
                double coins = double.Parse(input);
                switch (coins)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1.0:
                    case 2.0:
                        sum += coins;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {coins}");
                        break;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                double priceOfProduct = 0;

                switch (input)
                {
                    case "Nuts":
                        priceOfProduct = 2.0;
                        break;
                    case "Water":
                        priceOfProduct = 0.7;
                        break;
                    case "Crisps":
                        priceOfProduct = 1.5;
                        break;
                    case "Soda":
                        priceOfProduct = 0.8;
                        break;
                    case "Coke":
                        priceOfProduct = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        input = Console.ReadLine();
                        continue;
                }
                if (priceOfProduct <= sum)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                    sum -= priceOfProduct;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {sum:F2}");
        }
    }
}
