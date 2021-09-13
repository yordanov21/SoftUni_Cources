using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            double existingMoney = double.Parse(Console.ReadLine());

            int days = 0;
            double savedMoney = existingMoney;
            double dayMoney = 0;
            string variant = string.Empty;
            double spendDays = 0;

            while (vacationPrice > savedMoney)
            {
                variant = Console.ReadLine();

                if (variant == "spend")
                {
                    dayMoney = double.Parse(Console.ReadLine());
                    if (dayMoney > savedMoney)
                    {
                        savedMoney = 0;
                        dayMoney = 0;
                    }
                    savedMoney -= dayMoney;
                    spendDays++;
                    if (spendDays == 5)
                    {
                        days++;
                        break;
                    }
                }
                else if (variant == "save")
                {
                    dayMoney = double.Parse(Console.ReadLine());
                    savedMoney += dayMoney;
                    spendDays = 0;
                }


                days++;
            }

            if (vacationPrice <= savedMoney)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else if (spendDays >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }


        }
    }
}
