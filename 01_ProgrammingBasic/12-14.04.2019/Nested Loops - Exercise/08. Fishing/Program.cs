using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int fishNumber = int.Parse(Console.ReadLine());

            string fishName = string.Empty;

            double fishWeight = 0;
            int fishCounter = 0;
            double Price = 0;
            double priceFish = 0;
            double profit = 0;

            while (fishName != "Stop")
            {
                fishName = Console.ReadLine();
                if (fishName == "Stop")
                {
                    break;
                }
                fishWeight = double.Parse(Console.ReadLine());
                fishCounter++;

                for (int a= 0; a < fishName.Length; a++)
                {
                    char symbol = fishName[a];
                    
                    priceFish += symbol ;
                    Price = priceFish / fishWeight;
                }
                if (fishCounter % 3 == 0)
                {
                    profit += Price;
                    priceFish = 0;
                }
                else
                {
                    profit -= Price;
                    priceFish = 0;
                }
                if (fishCounter == fishNumber)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    if (profit >= 0)
                    {
                        Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {profit:f2} leva.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Lyubo lost {Math.Abs(profit):f2} leva today.");
                        break;
                    
                    }
                }
            }
            if (fishName == "Stop")
            {
                if (profit >= 0)
                {
                    Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {profit:f2} leva.");
                }
                else
                {
                    Console.WriteLine($"Lyubo lost {Math.Abs(profit):f2} leva today.");
                }
            }
            
        }
    }
}
