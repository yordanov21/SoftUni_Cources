using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string film = Console.ReadLine();
            string hall = Console.ReadLine();
            double tikets = double.Parse(Console.ReadLine());
            if (film== "A Star Is Born")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{film} -> {tikets*7.50:f2} lv.");
                }
                else if (hall=="luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 10.50:f2} lv.");
                }
                else if (hall=="ultra luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 13.50:f2} lv.");
                }
            }
             else if (film == "Bohemian Rhapsody")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{film} -> {tikets * 7.35:f2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 9.45:f2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 12.75:f2} lv.");
                }
            }
            else if (film == "Green Book")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{film} -> {tikets * 8.15:f2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 10.25:f2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 13.25:f2} lv.");
                }
            }
            else if (film == "The Favourite")
            {
                if (hall == "normal")
                {
                    Console.WriteLine($"{film} -> {tikets * 8.75:f2} lv.");
                }
                else if (hall == "luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 11.55:f2} lv.");
                }
                else if (hall == "ultra luxury")
                {
                    Console.WriteLine($"{film} -> {tikets * 13.95:f2} lv.");
                }
            }
        }
    }
}
