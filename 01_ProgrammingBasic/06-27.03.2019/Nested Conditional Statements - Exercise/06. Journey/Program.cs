using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (budjet <= 100)
            {
                if (season == "summer")
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {0.3 * budjet:f2}");
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {0.70 * budjet:f2}");
                }
            }
            else if (budjet > 100 && budjet <= 1000)
            {
                if (season == "summer")
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {0.4 * budjet:f2}");
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {0.8 * budjet:f2}");
                }
            }
            else if (budjet > 1000)
            {


                Console.WriteLine("Somewhere in Europe");
                Console.WriteLine($"Hotel - {0.9 * budjet:f2}");


            }

        }
    }
}
