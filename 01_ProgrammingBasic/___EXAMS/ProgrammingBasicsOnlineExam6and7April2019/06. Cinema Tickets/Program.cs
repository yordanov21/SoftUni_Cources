using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string comandFilm = string.Empty;
            string filmtipe = string.Empty;
            int masterCounter = 0;
            int Allcounter = 0;
            int studentcounter = 0;
            int standartcounter = 0;
            int kidcounter = 0;
            while (comandFilm != "Finish")
            {
                comandFilm = Console.ReadLine();
                if (comandFilm == "Finish")
                {
                    break;
                }
                double freeSeats = double.Parse(Console.ReadLine());
                for (int i = 1; i <= freeSeats; i++)
                {
                    filmtipe = Console.ReadLine();
                    if (filmtipe == "End")
                    {
                        double presentEnd = Allcounter / freeSeats * 100.0;
                        Console.WriteLine($"{comandFilm} - {presentEnd:f2}% full.");
                        Allcounter = 0;
                        break;
                    }
                    else if (filmtipe == "student")
                    {
                        Allcounter++;
                        studentcounter++;
                        masterCounter++;
                        if (Allcounter == freeSeats)
                        {
                            Console.WriteLine($"{comandFilm} - {Allcounter / freeSeats * 100.0:f2}% full.");
                            Allcounter = 0;
                            break;
                        }
                    }
                    else if (filmtipe == "standard")
                    {
                        Allcounter++;
                        standartcounter++;
                        masterCounter++;
                        if (Allcounter == freeSeats)
                        {
                            Console.WriteLine($"{comandFilm} - {Allcounter / freeSeats * 100.0:f2}% full.");
                            Allcounter = 0;
                            break;
                        }
                    }
                    else if (filmtipe == "kid")
                    {
                        Allcounter++;
                        kidcounter++;
                        masterCounter++;
                        if (Allcounter == freeSeats)
                        {
                            Console.WriteLine($"{comandFilm} - {Allcounter / freeSeats * 100.0:f2}% full.");
                            Allcounter = 0;
                            break;

                        }
                    }

                }

            }
            Console.WriteLine($"Total tickets: {masterCounter}");
            Console.WriteLine($"{(double)studentcounter / masterCounter * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standartcounter / masterCounter * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kidcounter / masterCounter * 100:f2}% kids tickets.");
        }
    }
}
