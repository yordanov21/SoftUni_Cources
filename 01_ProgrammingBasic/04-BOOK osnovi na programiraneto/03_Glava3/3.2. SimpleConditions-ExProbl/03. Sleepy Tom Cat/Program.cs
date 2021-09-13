using System;

namespace _03._Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysoff = int.Parse(Console.ReadLine());

            int playtime = daysoff * 127 + (365 - daysoff) * 63;
            int platimeDiferense = Math.Abs(30000 - playtime);
            int hours = platimeDiferense / 60;
            int minutes = platimeDiferense - hours * 60;
            if (playtime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }
    }
}
