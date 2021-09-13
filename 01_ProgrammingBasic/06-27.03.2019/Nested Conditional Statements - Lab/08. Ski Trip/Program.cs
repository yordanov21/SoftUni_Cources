using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string score = Console.ReadLine();
            double price = 0.0;
            double priceOff1 = 0.0;

            double roomForOnePerson = 18.00;
            double apartament = 25.00;
            double presidentApartament = 35.00;

            if (room == "room for one person")
            {
                if (score == "positive")
                {
                    price = (days - 1) * roomForOnePerson + (days - 1) * roomForOnePerson * 0.25;
                    Console.WriteLine($"{price:f2}");
                }
                else if (score == "negative")
                {
                    price = (days - 1) * roomForOnePerson - (days - 1) * roomForOnePerson * 0.1;
                    Console.WriteLine($"{price:f2}");
                }
            }
            else if (room == "apartment")
            {
                price = (days - 1) * apartament;
                if (days < 10)
                {
                    priceOff1 = price - 0.3 * price;

                }
                else if (days >= 10 && days <= 15)
                {
                    priceOff1 = price - 0.35 * price;
                }
                else if (days >= 15)
                {
                    priceOff1 = price - 0.50 * price;
                }

                if (score == "positive")
                {
                    priceOff1 = priceOff1 + 0.25 * priceOff1;
                    Console.WriteLine($"{priceOff1:f2}");
                }
                else if (score == "negative")
                {
                    priceOff1 = priceOff1 - 0.1 * priceOff1;
                    Console.WriteLine($"{priceOff1:f2}");
                }


            }
            else if (room == "president apartment")
            {
                price = (days - 1) * presidentApartament;
                if (days < 10)
                {
                    priceOff1 = price - 0.1 * price;

                }
                else if (days >= 10 && days <= 15)
                {
                    priceOff1 = price - 0.15 * price;
                }
                else if (days >= 15)
                {
                    priceOff1 = price - 0.20 * price;
                }

                if (score == "positive")
                {
                    priceOff1 = priceOff1 + 0.25 * priceOff1;
                    Console.WriteLine($"{priceOff1:f2}");
                }
                else if (score == "negative")
                {
                    priceOff1 = priceOff1 - 0.1 * priceOff1;
                    Console.WriteLine($"{priceOff1:f2}");
                }


            }
        }
    }
}
