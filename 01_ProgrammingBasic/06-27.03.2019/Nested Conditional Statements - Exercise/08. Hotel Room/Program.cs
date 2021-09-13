using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());

            double apartametPrice = 0;
            double studioPrice = 0;

            if (month == "May" || month == "October")
            {
                if (nights <= 7)
                {
                    apartametPrice = 65 * nights;
                    studioPrice = 50 * nights;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");

                }
                else if (nights > 7 && nights <= 14)
                {
                    apartametPrice = 65 * nights;
                    studioPrice = 50 * nights - 50 * nights * 0.05;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");
                }
                else if (nights > 14)
                {
                    apartametPrice = 65 * nights - 65 * nights * 0.1;
                    studioPrice = 50 * nights - 50 * nights * 0.30;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");
                }
            }
            else if (month == "June" || month == "September")
            {
                if (nights <= 14)
                {
                    apartametPrice = 68.7 * nights;
                    studioPrice = 75.2 * nights;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");

                }
                else if (nights > 14)
                {
                    apartametPrice = 68.7 * nights - 68.7 * nights * 0.1;
                    studioPrice = 75.2 * nights - 75.2 * nights * 0.20;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");

                }
            }
            else if (month == "July" || month == "August")
            {
                if (nights <= 14)
                {
                    apartametPrice = 77 * nights;
                    studioPrice = 76 * nights;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");

                }
                else if (nights > 14)
                {
                    apartametPrice = 77 * nights - 77 * nights * 0.1;
                    studioPrice = 76 * nights;
                    Console.WriteLine($"Apartment: {apartametPrice:f2} lv.");
                    Console.WriteLine($"Studio: {studioPrice:f2} lv.");

                }
            }
        }
    }
}
