using System;

namespace _01._Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string dayPart = Console.ReadLine();

            double priceTravelPerTaxi = 0;
            double priceTravelPerBus = 0;
            double priceTravelPerTrain = 0;
           

            if (dayPart == "day")
            {
                priceTravelPerTaxi = 0.7 + kilometers * 0.79;
                if (kilometers>=20)
                {
                    priceTravelPerBus = kilometers * 0.09;
                }
                else
                {
                    priceTravelPerBus = priceTravelPerTaxi;
                }
                if (kilometers >= 100)
                {
                   priceTravelPerTrain = kilometers * 0.06;
                }
                else
                {
                    priceTravelPerTrain = priceTravelPerTaxi;
                }
            }
            else if (dayPart == "night")
            {
                priceTravelPerTaxi = 0.7 + kilometers * 0.9;
                if (kilometers >= 20)
                {
                    priceTravelPerBus = kilometers * 0.09;
                }
                else
                {
                    priceTravelPerBus = priceTravelPerTaxi;
                }
                if (kilometers >= 100)
                {
                    priceTravelPerTrain = kilometers * 0.06;
                }
                else
                {
                    priceTravelPerTrain = priceTravelPerTaxi;
                }
            }
            double firstLowPrice = Math.Min(priceTravelPerTaxi, priceTravelPerBus);
            double lastLowPrice = Math.Min(firstLowPrice, priceTravelPerTrain);
            Console.WriteLine(lastLowPrice);
        }
    }
}
