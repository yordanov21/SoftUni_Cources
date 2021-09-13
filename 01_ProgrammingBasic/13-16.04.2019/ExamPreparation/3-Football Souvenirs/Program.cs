using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string souvenir = Console.ReadLine();
            int NumOfSouveniers = int.Parse(Console.ReadLine());
            
          
            
            if (country == "Argentina")
            {
                if (souvenir == "flags")
                {
                    
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {3.25*NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "caps")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {7.20 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "posters")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {5.10 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "stickers")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {1.25 * NumOfSouveniers:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (country == "Brazil")
            {
                if (souvenir == "flags")
                {

                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {4.20 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "caps")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {8.50 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "posters")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {5.35 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "stickers")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {1.20 * NumOfSouveniers:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (country == "Croatia")
            {
                if (souvenir == "flags")
                {

                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {2.75 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "caps")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {6.90 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "posters")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {4.95 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "stickers")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {1.10 * NumOfSouveniers:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else if (country == "Denmark")
            {
                if (souvenir == "flags")
                {

                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {3.10 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "caps")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {6.50 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "posters")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {4.80 * NumOfSouveniers:f2} lv.");
                }
                else if (souvenir == "stickers")
                {
                    Console.WriteLine($"Pepi bought {NumOfSouveniers} {souvenir} of {country} for {0.90 * NumOfSouveniers:f2} lv.");
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
            }

        }
    }
}
