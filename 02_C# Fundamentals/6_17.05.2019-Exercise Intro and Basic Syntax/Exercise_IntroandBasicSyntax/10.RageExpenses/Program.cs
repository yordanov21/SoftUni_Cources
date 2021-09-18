using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headset = double.Parse(Console.ReadLine());
            double mouse = double.Parse(Console.ReadLine());
            double keyboard = double.Parse(Console.ReadLine());
            double display = double.Parse(Console.ReadLine());

            int quantityHeadset = 0;
            int quantityMouse = 0;
            int quantityBoard = 0;
            int quantityDisplay = 0;


            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    quantityHeadset++;
                }
                if (i % 3 == 0)
                {
                    quantityMouse++;
                }
                if (i % 6 == 0)
                {
                    quantityBoard++;
                }
                if (i % 12 == 0)
                {
                    quantityDisplay++;
                }

            }
            double total = quantityHeadset * headset + quantityMouse * mouse + quantityBoard * keyboard + quantityDisplay * display;

            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}
