using System;

namespace _05._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nigths = int.Parse(Console.ReadLine());

            double apartamentPrice = 0;
            double studioPrice = 0;

            if (month == "May" || month == "October")
            {
                apartamentPrice = nigths * 65.0;
                studioPrice = nigths * 50.0;
                if (nigths > 7 && nigths <= 14)
                {
                    studioPrice = studioPrice * 0.95;
                }
                if (nigths > 14)
                {
                    studioPrice = studioPrice * 0.70;
                    apartamentPrice = apartamentPrice * 0.9;
                }
            }
            else if (month == "June" || month == "September")
            {
                apartamentPrice = nigths * 68.70;
                studioPrice = nigths * 75.20;
                if (nigths > 14)
                {
                    studioPrice = studioPrice * 0.80;
                    apartamentPrice = apartamentPrice * 0.9;
                }
            }
            else if (month == "July" || month == "August")
            {
                apartamentPrice = nigths * 77.0;
                studioPrice = nigths * 76.0;
                if (nigths > 14)
                {
                    apartamentPrice = apartamentPrice * 0.9;
                }
            }

            Console.WriteLine($"Apartment: {apartamentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
