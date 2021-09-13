using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());
            double shouse = tax - 0.40 * tax;
            double ekip = shouse - 0.2 * shouse;
            double ball = ekip * 0.25;
            double aksesoari = ball * 0.20;
            double sum = shouse + ekip + ball + aksesoari + tax;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
