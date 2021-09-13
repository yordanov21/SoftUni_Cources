using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceHoliday = double.Parse(Console.ReadLine());
            int Puzzels = int.Parse(Console.ReadLine());
            int Barbies = int.Parse(Console.ReadLine());
            int TedyBears = int.Parse(Console.ReadLine());
            int Minions = int.Parse(Console.ReadLine());
            int MiniTrucks = int.Parse(Console.ReadLine());

            double PuzzelsPrice = 2.60;
            double BarbiesPrice = 3.00;
            double TedyBearsPrice = 4.10;
            double MinionsPrice = 8.20;
            double MiniTrucksPrice = 2.00;

            double SUM = Puzzels * PuzzelsPrice + Barbies * BarbiesPrice + TedyBears * TedyBearsPrice + Minions * MinionsPrice + MiniTrucks * MiniTrucksPrice;
            int toys = Puzzels + Barbies + TedyBears + Minions + MiniTrucks;
            double discount = 0.00;
            if (toys >= 50)
            {
                discount = SUM * 0.25;
             
            }
            double totalPrice = SUM - discount;
            totalPrice = totalPrice - (totalPrice * 0.10);
            if (totalPrice >= priceHoliday)
            {
                Console.WriteLine("Yes! {0:f2} lv left.", totalPrice - priceHoliday);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:f2} lv needed.",Math.Abs(totalPrice - priceHoliday));

            }


        }
    }
}
