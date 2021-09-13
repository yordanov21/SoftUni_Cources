using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {


            string destinacion = Console.ReadLine();
         
            double savedMoney = 0;

            while (destinacion != "End")
            {
                double budjet = double.Parse(Console.ReadLine());
                while (budjet >= savedMoney)
                {
                    double Money = double.Parse(Console.ReadLine());
                    savedMoney += Money;
                    if (savedMoney >= budjet)
                    {
                        Console.WriteLine($"Going to {destinacion}!");
                        savedMoney = 0;
                        break;
                    }
                }
               destinacion = Console.ReadLine();

            }
        }
    }
}
