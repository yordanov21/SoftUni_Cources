using System;

namespace _11._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionTipe = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int cells = int.Parse(Console.ReadLine());
            double totalIncome = 0;
            if (projectionTipe == "premiere")
            {
                totalIncome = 12.00 * rows * cells;
                Console.WriteLine("{0:f2} leva", totalIncome);
            }
            else if (projectionTipe == "normal")
            {
                totalIncome = 7.50 * rows * cells;
                Console.WriteLine("{0:f2} leva",totalIncome);
            }
            else if (projectionTipe == "discount")
            {
                totalIncome = 5.00 * rows * cells;
                Console.WriteLine("{0:f2} leva", totalIncome);
            }

        }
    }
}
