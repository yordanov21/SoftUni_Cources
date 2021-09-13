using System;

namespace _05._Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectHours = int.Parse(Console.ReadLine());
            double days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            days = 0.9 * days;
            double extraHours = days * workers * 2;         
            double hours = days * 8 * workers + extraHours;
            hours = Math.Floor(hours);
            double difference = Math.Abs(projectHours - hours);
            if (projectHours <= hours)
            {
                Console.WriteLine($"Yes!{difference} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{difference} hours needed.");
            }
        }
    }
}
