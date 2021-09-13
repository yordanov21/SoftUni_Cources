using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tounarments = int.Parse(Console.ReadLine());
            double FirstPoints = double.Parse(Console.ReadLine());
            double points = FirstPoints;
            double avaragePolints = 0;
            double counterWin = 0;
            double presentWin = 0;
            for (int i = 1; i <= tounarments; i++)
            {
                string stageTounarmets = Console.ReadLine();
                switch (stageTounarmets)
                {
                    case "W":  points += 2000; counterWin++; presentWin = counterWin / tounarments * 100; break;
                    case "F": points += 1200; break;
                    case "SF": points += 720; break;
                }
             
            }
            avaragePolints = Math.Floor((points-FirstPoints) / tounarments);
            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {avaragePolints}");
            Console.WriteLine($"{presentWin:f2}%");
        }
    }
}
