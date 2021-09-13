using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int startHour = int.Parse(Console.ReadLine());
            int startMinute = int.Parse(Console.ReadLine());

            int timeInMinutes = startHour * 60 + startMinute;
            int timePlus15 = timeInMinutes + 15;
            int Hours = timePlus15 / 60;
            int Minutes = timePlus15 % 60;
            if (Hours >= 24)
            {
                Hours -= 24;
            }
            if (Minutes >= 60)
            {
                Minutes -= 60;
            }
            if (Minutes < 9)
            { 
                Console.WriteLine("{0}:0{1}",Hours,Minutes);
            }
            else
            {
                Console.WriteLine("{0}:{1}", Hours, Minutes);

            }

        }
    }
}
