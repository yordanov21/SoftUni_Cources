using System;

namespace _12._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekends = double.Parse(Console.ReadLine());

            double weekendSofia = (48 - weekends) * (3.0 / 4.0);
            double holidaysPlay = holidays * (2.0 / 3.0);
            double Playeddays = weekendSofia + holidaysPlay + weekends;
            if (year == "leap")
            {
                Playeddays = Playeddays + Playeddays * 0.15;
                Console.WriteLine(Math.Floor(Playeddays));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(Playeddays));
            }
        }
    }
}
