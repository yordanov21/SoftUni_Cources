using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int Degrees = int.Parse(Console.ReadLine());
            string dayTime =Console.ReadLine();
            string outfit = string.Empty;
            string shoes = string.Empty;

            if (Degrees>=10 && Degrees <= 18)
            {
                if (dayTime == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Afternoon")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
               
            }
            else if(Degrees>18 && Degrees <= 24)
            {
                if (dayTime == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
            }
            else if (Degrees >= 25)
            {
                if (dayTime == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
                else if (dayTime == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {Degrees} degrees, get your {outfit} and {shoes}.");
                }
            }
        }
    }
}
