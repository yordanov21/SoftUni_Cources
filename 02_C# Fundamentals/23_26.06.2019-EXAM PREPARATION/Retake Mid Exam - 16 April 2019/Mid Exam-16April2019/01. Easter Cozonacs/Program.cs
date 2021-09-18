using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double price1kgFloor = double.Parse(Console.ReadLine());

            double price1PackEggs = 0.75 * price1kgFloor;
            double price1LitterMilk = price1kgFloor + 0.25 * price1kgFloor;
            double priceMilkPerCozonac = 0.25 * price1LitterMilk;
            double TotalPricePerCozonac = price1PackEggs + price1kgFloor + priceMilkPerCozonac;
            double AllPriceForCozonac = TotalPricePerCozonac; 
            int counterCozonac = 0;
            int counterColoredEggs = 0;
           while (AllPriceForCozonac < budget-TotalPricePerCozonac)
            {
                counterCozonac++;
                counterColoredEggs += 3;
                if (counterCozonac % 3==0 )
                {
                    counterColoredEggs -= counterCozonac - 2;
                    if (counterColoredEggs < 0)
                    {
                        counterCozonac--;
                        counterColoredEggs += counterCozonac - 2-3;
                        AllPriceForCozonac = TotalPricePerCozonac * counterCozonac;
                        break;
                    }
                }
                AllPriceForCozonac = TotalPricePerCozonac * counterCozonac;
                //if (counterCozonac == 20)
                //{
                //    break;
                //}
            }

           
            double leftBuget = budget - AllPriceForCozonac;
            Console.WriteLine($"You made {counterCozonac} cozonacs! Now you have {counterColoredEggs} eggs and {leftBuget:f2}BGN left.");
        }
    }
}
