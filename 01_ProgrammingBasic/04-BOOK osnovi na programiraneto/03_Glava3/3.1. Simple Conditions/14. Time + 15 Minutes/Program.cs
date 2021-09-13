using System;

namespace _14._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes = hours * 60 + minutes + 15;
            hours = minutes / 60;
            minutes = minutes - hours * 60;
            if (hours > 23)
            {
                hours -= 24;
            }

            if (minutes < 10)
            {
                Console.WriteLine(hours + ":" + "0" + minutes);
            }
            else
            {
                Console.WriteLine(hours + ":" + minutes);
            }
        }
    }
}
