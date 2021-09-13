using System;

namespace _02._Magic_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            var startYear = int.Parse(Console.ReadLine());
            var finalYear = int.Parse(Console.ReadLine());
            var weight = int.Parse(Console.ReadLine());

            DateTime currentDate = new DateTime(startYear, 1, 1);
            bool found = false;
            while (currentDate.Year <= finalYear)
            {
                int d1 = currentDate.Day / 10;
                int d2 = currentDate.Day % 10;
                int d3 = currentDate.Month / 10;
                int d4 = currentDate.Month % 10;
                int d5 = currentDate.Year / 1000;
                int d6 = currentDate.Year / 100 % 10;
                int d7 = currentDate.Year / 10 % 10;
                int d8 = currentDate.Year % 10;
                int dateWeight = d1 * (d2 + d3 + d4 + d5 + d6 + d7 + d8) + d2 * (d3 + d4 + d5 + d6 + d7 + d8) +
                    d3 * (d4 + d5 + d6 + d7 + d8) + d4 * (d5 + d6 + d7 + d8) + d5 * (d6 + d7 + d8) + d6 * (d7 + d8) + d7 * d8;

                if (dateWeight == weight)
                {
                    Console.WriteLine(currentDate.ToString("dd-MM-yyyy"));
                    found= true;
                }
                currentDate = currentDate.AddDays(1);
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}
