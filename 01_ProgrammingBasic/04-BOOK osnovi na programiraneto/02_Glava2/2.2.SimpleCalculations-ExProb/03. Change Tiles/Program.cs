using System;

namespace _03._Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSquer = double.Parse(Console.ReadLine());

            double Wtile = double.Parse(Console.ReadLine());
            double Ltile = double.Parse(Console.ReadLine());

            int Mbench = int.Parse(Console.ReadLine());
            int Obench = int.Parse(Console.ReadLine());
            double area = sideSquer * sideSquer - Mbench * Obench;
            double tileArea = Wtile * Ltile;
            double tiles = area / tileArea;
            double time = tiles * 0.2;
            Console.WriteLine(tiles);
            Console.WriteLine(time);

        }
    }
}
