using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startyield = int.Parse(Console.ReadLine());

            int spiceMined = 0;

            int dropdownYieldCoust = 10;
            int workerConsume = 26;
            int days = 0;

            while (startyield >= 100)
            {
                spiceMined += startyield;
                spiceMined -= workerConsume;
                startyield -= dropdownYieldCoust;
                days++;
            }
            if (spiceMined != 0)
            {
                spiceMined -= workerConsume;
            }
            Console.WriteLine(days);
            Console.WriteLine(spiceMined);
        }
    }
}
