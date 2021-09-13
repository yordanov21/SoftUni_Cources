using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double TimefirstBrother = double.Parse(Console.ReadLine());
            double TimesecondBrother = double.Parse(Console.ReadLine());
            double TimethirdBrother = double.Parse(Console.ReadLine());
            double TimeFishingFather = double.Parse(Console.ReadLine());
            double timeCleaning = 1/(1/TimefirstBrother + 1/TimesecondBrother + 1/TimethirdBrother);
            double Alltime = timeCleaning*1.15;
            double leftTime = TimeFishingFather - Alltime;
            Console.WriteLine($"Cleaning time: {Alltime:f2}");
            if (leftTime>=0)
            {
                
                Console.WriteLine("Yes, there is a surprise - time left -> {0:f0} hours.",Math.Floor(leftTime));
            }
            else
            {
                
                Console.WriteLine("No, there isn't a surprise - shortage of time -> {0:f0} hours.",Math.Ceiling(Math.Abs(leftTime)));
            }
        }
    }
}
