using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsNUM = int.Parse(Console.ReadLine());
            
            int redCounter = 0;
            int orangeCounter = 0;
            int blueCounter = 0;
            int greenCounter = 0;
            string maxeggcolor = string.Empty;
            int Maxcounter = 0;

            string color = string.Empty;

            for (int i = 1; i <= eggsNUM; i++)
            {
                color = Console.ReadLine();
                switch (color)
                {
                    case "red": redCounter++; break;
                    case "orange": orangeCounter++; break;
                    case "blue": blueCounter++; break;
                    case "green": greenCounter++; break;
                }
            }
            if(redCounter>orangeCounter&&redCounter>blueCounter&& redCounter > greenCounter)
            {
                maxeggcolor = "red";
            }
            else if(orangeCounter>redCounter&&orangeCounter>blueCounter&& orangeCounter > greenCounter)
            {
                maxeggcolor = "orange";
            }
            else if(blueCounter>redCounter&& blueCounter>orangeCounter&& blueCounter > greenCounter)
            {
                maxeggcolor = "blue";          
            }
            else
            {
                maxeggcolor = "green";
            }
            int maxCounter1 = Math.Max(redCounter, orangeCounter);
            int maxCounter2 = Math.Max(blueCounter, greenCounter);
            int maxCounter = Math.Max(maxCounter1, maxCounter2);
            Console.WriteLine($"Red eggs: {redCounter}");
            Console.WriteLine($"Orange eggs: {orangeCounter}");
            Console.WriteLine($"Blue eggs: {blueCounter}");
            Console.WriteLine($"Green eggs: {greenCounter}");  
            Console.WriteLine($"Max eggs: {maxCounter} -> {maxeggcolor}");
        }
    }
}
