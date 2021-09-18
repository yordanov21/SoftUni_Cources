using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());

            double totalWater = waterPerDayPerPerson * players*days;
            double totalFood = foodPerDayPerPerson * players*days;

            for (int i = 1; i <= days; i++)
            {
                double lossEnergy = double.Parse(Console.ReadLine());
                groupEnergy -= lossEnergy;
                if (groupEnergy <= 0)
                {
                    break;
                }
                if (i % 2 == 0)
                {
                    groupEnergy += 0.05 * groupEnergy;
                    totalWater -= 0.3 * totalWater;
                }
                if (i % 3 == 0)
                {
                    totalFood -= (totalFood/ players);
                    groupEnergy += 0.1 * groupEnergy;
                }

            }

            if (groupEnergy > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:F2} water.");
            }

        }
    }
}
