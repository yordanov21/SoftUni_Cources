using System;

namespace _09
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = DateTime.Today.DayOfWeek;
            var nextday = DateTime.Today.AddDays(50);
            Console.WriteLine(DateTime.Today.DayOfWeek);
            Console.WriteLine(today);
            Console.WriteLine(nextday);
        }
    }
}
