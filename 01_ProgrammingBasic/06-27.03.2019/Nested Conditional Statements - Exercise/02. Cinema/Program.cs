using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());

            double income = 0.00;
            if (type == "Premiere")
            {
                income = rows * colums * 12;
                Console.WriteLine($"{income:F2} leva");
            }
            else if (type == "Normal")
            {
                income = rows * colums * 7.50;
                Console.WriteLine($"{income:F2} leva");
            }
            else if (type=="Discount")
            {
                income = rows * colums * 5;
                Console.WriteLine($"{income:F2} leva");
            }
        }
    }
}
