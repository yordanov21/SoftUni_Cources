using System;

namespace _07._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string dayOfWeek = Console.ReadLine().ToLower();
            double quantity = double.Parse(Console.ReadLine());

            if (dayOfWeek == "monday" || dayOfWeek == "tuesday" || dayOfWeek == "wednesday" || dayOfWeek == "thursday" || dayOfWeek == "friday")
            {
                if (fruit == "banana")
                {
                    double price = quantity * 2.50;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "apple")
                {
                    double price = quantity * 1.20;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "orange")
                {
                    double price = quantity * 0.85;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double price = quantity * 1.45;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double price = quantity * 2.70;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double price = quantity * 5.50;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapes")
                {
                    double price = quantity * 3.85;
                    Console.WriteLine($"{price:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if(dayOfWeek == "sunday" || dayOfWeek == "saturday")
            {
                if (fruit == "banana")
                {
                    double price = quantity * 2.70;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "apple")
                {
                    double price = quantity * 1.25;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "orange")
                {
                    double price = quantity * 0.90;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    double price = quantity * 1.60;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "kiwi")
                {
                    double price = quantity * 3.00;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "pineapple")
                {
                    double price = quantity * 5.60;
                    Console.WriteLine($"{price:f2}");
                }
                else if (fruit == "grapes")
                {
                    double price = quantity * 4.20;
                    Console.WriteLine($"{price:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
