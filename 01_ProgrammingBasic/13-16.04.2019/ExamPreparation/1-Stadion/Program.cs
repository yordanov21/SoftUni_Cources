using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Stadion
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectors = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double tiketPrice = double.Parse(Console.ReadLine());

            double income = tiketPrice * capacity;
            double incomeSector = income / sectors;
            double charity = (income - (incomeSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {income:f2} BGN");
            Console.WriteLine($"Money for charity - { charity:f2} BGN");
        }
    }
}
