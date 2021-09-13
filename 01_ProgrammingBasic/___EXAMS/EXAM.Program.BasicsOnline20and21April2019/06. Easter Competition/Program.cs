using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int playrs = int.Parse(Console.ReadLine());
            string NamePlayer = string.Empty;
            string ocenka = string.Empty;
            int counter1 = 0;
            int maxCounter = int.MinValue;
            string Player = string.Empty;



            for (int i = 1; i <= playrs; i++)
            {
                NamePlayer = Console.ReadLine();
                                             
                while (ocenka != "Stop")
                {
                    ocenka = Console.ReadLine();
                    if (ocenka == "Stop")
                    {
                        ocenka = string.Empty;
                        break;
                    }
                    int ocenkaINT = int.Parse(ocenka);
                    counter1 += ocenkaINT;                   
                }
                Console.WriteLine($"{NamePlayer} has {counter1} points.");
                if (maxCounter < counter1)
                {
                    maxCounter = counter1;
                    Player = NamePlayer;
                    Console.WriteLine($"{NamePlayer} is the new number 1!");
                }
                counter1 = 0;

            }
            Console.WriteLine($"{Player} won competition with {maxCounter} points!");
        }
    }
}
