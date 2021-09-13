using System;

namespace _04._Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double BujetForTransport = 0;
            if (people < 5)
            {
                BujetForTransport = 0.75 * bujet;
            }
            else if (people >= 5 && people <= 9)
            {
                BujetForTransport = 0.60 * bujet;
            }
            else if (people >= 10 && people <= 24)
            {
                BujetForTransport = 0.50 * bujet;
            }
            else if (people >= 25 && people <= 49)
            {
                BujetForTransport = 0.40 * bujet;
            }
            else if (people >= 50)
            {
                BujetForTransport = 0.25 * bujet;
            }

            double bujetForTicket = bujet - BujetForTransport;
            double ticketsPice = 0.0;

            if (category == "VIP")
            {
                 ticketsPice = people * 499.99;
            }
            else if (category == "Normal")
            {
                ticketsPice = people * 249.99;
            }

            if (bujetForTicket >= ticketsPice)
            {
                Console.WriteLine($"Yes! You have {bujetForTicket-ticketsPice:f2} leva left.");
            }
            else
            {
                double diff = ticketsPice - bujetForTicket;
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
            }
        }
    }
}
