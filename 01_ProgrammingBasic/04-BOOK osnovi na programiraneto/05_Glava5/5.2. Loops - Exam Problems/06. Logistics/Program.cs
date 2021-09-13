using System;

namespace _06._Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargoNum = int.Parse(Console.ReadLine());
            int allCargo = 0;
            int cargoBus = 0;
            int cargoTrack = 0;
            int cargoTrain = 0;

            for (int i = 0; i <cargoNum; i++)
            {
                int cargoWeigth = int.Parse(Console.ReadLine());
                allCargo += cargoWeigth;
                if (cargoWeigth <= 3)
                {
                    cargoBus += cargoWeigth;
                }
                else if (cargoWeigth > 3 && cargoWeigth <= 11)
                {
                    cargoTrack += cargoWeigth;
                }
                else if (cargoWeigth > 11)
                {
                    cargoTrain += cargoWeigth;
                }
            }
            double precentBus = (double)cargoBus / allCargo * 100;
            double precentTruck = (double)cargoTrack / allCargo * 100;
            double precentTrain = (double)cargoTrain / allCargo * 100;
            double pricePerTone=(double)(200*cargoBus+175*cargoTrack+120*cargoTrain)/ allCargo;

            Console.WriteLine($"{pricePerTone:f2}");
            Console.WriteLine($"{precentBus:f2}%");
            Console.WriteLine($"{precentTruck:f2}%");
            Console.WriteLine($"{precentTrain:f2}%");
        }
    }
}
