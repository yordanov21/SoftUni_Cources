using System;

namespace _02._Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string seasson = Console.ReadLine();

            if (seasson == "summer")
            {
                if (bujet <= 100)
                {
                    double sum = 0.3 * bujet;

                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Camp - {sum:f2}");
                }
                else if (bujet > 100 && bujet <= 1000)
                {
                    double sum = 0.4 * bujet;

                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Camp - {sum:f2}");
                }
                else if (bujet > 1000)
                {
                    double sum = 0.9 * bujet;
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine($"Hotel - {sum:f2}");
                }
            }
            else if (seasson == "winter")
            {
                if (bujet <= 100)
                {
                    double sum = 0.7 * bujet;

                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine($"Hotel - {sum:f2}");
                }
                else if (bujet > 100 && bujet <= 1000)
                {
                    double sum = 0.8 * bujet;

                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine($"Hotel - {sum:f2}");
                }
                else if (bujet > 1000)
                {
                    double sum = 0.9 * bujet;
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine($"Hotel - {sum:f2}");
                }
            }
        }
    }
}
