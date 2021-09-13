using System;

namespace _03._Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            double htizantems = double.Parse(Console.ReadLine());
            double rouses = double.Parse(Console.ReadLine());
            double laleta = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char day = char.Parse(Console.ReadLine());

            double flower = htizantems + rouses + laleta;
            double priceBuket = 0.0;
            if (day == 'N')
            {
                if (season == "Spring" || season == "Summer")
                {
                    priceBuket = 2 * htizantems + 4.1 * rouses + 2.5 * laleta;
                    if (laleta > 7 && season == "Spring")
                    {
                        priceBuket -= priceBuket * 0.05;
                    }
                }
                else if (season == "Autumn"||season=="Winter")
                {
                   priceBuket = 3.75 * htizantems + 4.50 * rouses + 4.15 * laleta;
                    if (rouses >= 10 && season == "Winter")
                    {
                        priceBuket -= priceBuket * 0.1;
                    }

                }

                if (flower > 20)
                {
                    priceBuket -= priceBuket * 0.2;
                }
                priceBuket += 2;
            }
            else if(day=='Y')
            {
                if (season == "Spring" || season == "Summer")
                {
                    priceBuket = 2 * htizantems*1.15 + 4.1 * rouses*1.15 + 2.5 * laleta*1.15;
                    if (laleta > 7 && season == "Spring")
                    {
                        priceBuket -= priceBuket * 0.05;
                    }
                }
                else if (season == "Autumn" || season == "Winter")
                {
                    priceBuket = 3.75 * htizantems*1.15 + 4.50 * rouses*1.15 + 4.15 * laleta*1.15;
                    if (rouses >= 10 && season == "Winter")
                    {
                        priceBuket -= priceBuket * 0.1;
                    }

                }

                if (flower > 20)
                {
                    priceBuket -= priceBuket * 0.2;
                }
                priceBuket += 2;
            }
            Console.WriteLine($"{priceBuket:f2}");
        }
    }
}
