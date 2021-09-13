using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double currentBalance = double.Parse(Console.ReadLine());

            int daysCount = 0;
            int spendDaysCount = 0;

            while (currentBalance < neededMoney)
            {
                string command = Console.ReadLine();
                double dailyMoney = double.Parse(Console.ReadLine());

                daysCount++;

                if (command == "spend")
                {
                    currentBalance -= dailyMoney;
                    if (currentBalance < 0)
                    {
                        currentBalance = 0;
                    }
                    spendDaysCount++;
                    if (spendDaysCount >= 5)
                    {
                        break;
                    }
                }
                else if (command == "save")
                {
                    currentBalance += dailyMoney;
                    spendDaysCount = 0;
                }
            }

            if (currentBalance >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.") ;
            }
            else if (spendDaysCount >= 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(daysCount);
            }

        }
    }
}
