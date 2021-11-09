using System;

namespace _03DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var today = DateTime.Today.DayOfWeek;
            var nextday = DateTime.Today.AddDays(2).DayOfWeek;
            Console.WriteLine(DateTime.Today.DayOfWeek); 
            Console.WriteLine(today); 
            Console.WriteLine(nextday); 
        }
    }
}
