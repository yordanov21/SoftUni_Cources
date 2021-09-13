using System;

namespace _04._Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double vinePerOneScm = double.Parse(Console.ReadLine());
            int littersWine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double harvestForWine = vinePerOneScm * vineyardArea * 0.4;
            double littersWineFromHarvest = harvestForWine / 2.5;

            double diference = littersWine - littersWineFromHarvest;

            if (littersWineFromHarvest < littersWine)
            {
                diference = Math.Floor(Math.Abs(diference));
                Console.WriteLine($"It will be a tough winter! More {diference} liters wine needed.");
            }
            else
            {
                littersWineFromHarvest = Math.Floor(littersWineFromHarvest);
                Console.WriteLine($"Good harvest this year! Total wine: {littersWineFromHarvest} liters.");

                diference =Math.Abs( Math.Ceiling(diference));
                double litersPerPerson = Math.Ceiling(diference / workers);
                Console.WriteLine($"{diference} liters left -> {litersPerPerson} liters per person.");
            }
        }
    }
}
