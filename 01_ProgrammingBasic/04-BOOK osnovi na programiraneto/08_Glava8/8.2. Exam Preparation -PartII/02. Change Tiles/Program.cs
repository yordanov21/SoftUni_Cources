using System;

namespace _02._Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double savedMoney = double.Parse(Console.ReadLine());
            double wigthFloor = double.Parse(Console.ReadLine());
            double leightFloor = double.Parse(Console.ReadLine());
            double sideTile = double.Parse(Console.ReadLine());
            double heightTile = double.Parse(Console.ReadLine());
            double tileprice = double.Parse(Console.ReadLine());
            double moneyForWorkerman = double.Parse(Console.ReadLine());

            double areaFoor = wigthFloor * leightFloor;
            double areaTile = sideTile * heightTile / 2;
            double tiles = Math.Ceiling(areaFoor / areaTile + 5);
            double totalPrice = tiles * tileprice + moneyForWorkerman;
            double diff = Math.Abs(savedMoney - totalPrice);

            if (totalPrice <= savedMoney)
            {
                Console.WriteLine($"{diff:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"You'll need {diff:f2} lv more.");
            }

        }
    }
}
