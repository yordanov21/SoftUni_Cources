using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fires = Console.ReadLine()
                .Split('#')
                .ToArray();
            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            int totalFire = 0;
            Console.WriteLine("Cells:");
            for (int i = 0; i < fires.Length; i++)
            {
                string[] CurentFire = fires[i]
                      .Split(" = ")
                      .ToArray();
                int fireNumber = int.Parse(CurentFire[1]);
                if (water-fireNumber <0)
                {
                    continue;
                }
                if(CurentFire[0]=="High"&& fireNumber>=81 && fireNumber <= 125)
                {
                    water -= fireNumber;
                    effort += 0.25 * fireNumber;
                    totalFire += fireNumber;
                    Console.WriteLine(" - "+fireNumber);
                }
                else if (CurentFire[0] == "Medium" && fireNumber >= 51 && fireNumber <= 80)
                {
                    water -= fireNumber;
                    effort += 0.25 * fireNumber;
                    totalFire += fireNumber;
                    Console.WriteLine(" - " + fireNumber);
                }
                else if (CurentFire[0] == "Low" && fireNumber >= 1 && fireNumber <= 50)
                {
                    water -= fireNumber;
                    effort += 0.25 * fireNumber;
                    totalFire += fireNumber;
                    Console.WriteLine(" - " + fireNumber);
                }
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
