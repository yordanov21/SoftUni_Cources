using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budjet = int.Parse(Console.ReadLine());
            int NumSouvenier = int.Parse(Console.ReadLine());
            string nameSouvenier = string.Empty;
            int souvenierCounter = 0;
            double MoneyCounter = 0.00;


            for (int i = 1; i <= NumSouvenier; i++)
            {
                nameSouvenier = Console.ReadLine();
                if (nameSouvenier == "hoodie")
                {
                    souvenierCounter++;
                    MoneyCounter += 30;
                }
                else if (nameSouvenier == "keychain")
                {
                    souvenierCounter++;
                    MoneyCounter += 4;
                }
                else if (nameSouvenier=="T-shirt")
                {
                    souvenierCounter++;
                    MoneyCounter += 20;
                }
                else if (nameSouvenier == "flag")
                {
                    souvenierCounter++;
                    MoneyCounter += 15;
                }
                else if (nameSouvenier == "sticker")
                {
                    souvenierCounter++;
                    MoneyCounter += 1;
                }
                else
                {
                    continue;
                }
            }
            double difference = Math.Abs(budjet - MoneyCounter);
            if (budjet >= MoneyCounter)
            {
                Console.WriteLine($"You bought {souvenierCounter} items and left with {difference:f0} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {difference:f0} more lv.");
            }
        }
    }
}
