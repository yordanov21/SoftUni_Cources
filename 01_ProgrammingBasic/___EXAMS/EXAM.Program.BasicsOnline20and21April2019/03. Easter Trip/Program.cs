using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string Date = Console.ReadLine();
            int night = int.Parse(Console.ReadLine());
            double PriceHoliday = 0.0;
            if (destination == "France")
            {
                switch(Date)
                {
                    case "21-23": PriceHoliday = 30.0 * night; break;
                    case "24-27": PriceHoliday = 35.0 * night; break;
                    case "28-31": PriceHoliday = 40.0 * night; break;
                }
            }
            else if (destination == "Italy")
            {
                switch (Date)
                {
                    case "21-23": PriceHoliday = 28.0 * night; break;
                    case "24-27": PriceHoliday = 32.0 * night; break;
                    case "28-31": PriceHoliday = 39.0 * night; break;
                }
            }
            else if (destination == "Germany")
            {
                switch (Date)
                {
                    case "21-23": PriceHoliday = 32.0 * night; break;
                    case "24-27": PriceHoliday = 37.0 * night; break;
                    case "28-31": PriceHoliday = 43.0 * night; break;
                }
            }
            Console.WriteLine($"Easter trip to {destination} : {PriceHoliday:f2} leva.");
        }
    }
}
