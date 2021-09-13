using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budjet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());

            double currentPrice = 0;
            double finalcurrentPrice = 0;
            double leftmoney = 0.0;

            if (season == "Spring")
            {
                currentPrice = 3000;
                if (fisherman <= 6)
                {
                    finalcurrentPrice = currentPrice - 0.1 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    finalcurrentPrice = currentPrice - 0.15 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
                else if (fisherman >= 12)
                {
                    finalcurrentPrice = currentPrice - 0.25 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
            }
            else if(season == "Summer")
            {
                currentPrice = 4200;
                if (fisherman <= 6)
                {
                    finalcurrentPrice = currentPrice - 0.1 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    finalcurrentPrice = currentPrice - 0.15 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
                else if (fisherman >= 12)
                {
                    finalcurrentPrice = currentPrice - 0.25 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
            }
            else if (season == "Autumn")
            {
                currentPrice = 4200;
                if (fisherman <= 6)
                {
                    finalcurrentPrice = currentPrice - 0.1 * currentPrice;
                    

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    finalcurrentPrice = currentPrice - 0.15 * currentPrice;
                   
                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
                else if (fisherman >= 12)
                {
                    finalcurrentPrice = currentPrice - 0.25 * currentPrice;
                   

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
            }
            else if (season == "Winter")
            {
                currentPrice = 2600;
                if (fisherman <= 6)
                {
                    finalcurrentPrice = currentPrice - 0.1 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    finalcurrentPrice = currentPrice - 0.15 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
                else if (fisherman >= 12)
                {
                    finalcurrentPrice = currentPrice - 0.25 * currentPrice;
                    if (fisherman % 2 == 0)
                    {
                        finalcurrentPrice = finalcurrentPrice - 0.05 * finalcurrentPrice;
                    }
                    else
                    {
                        finalcurrentPrice = finalcurrentPrice;
                    }

                    if (budjet >= finalcurrentPrice)
                    {
                        leftmoney = budjet - finalcurrentPrice;
                        Console.WriteLine($"Yes! You have {leftmoney:f2} leva left.");
                    }
                    else if (budjet < finalcurrentPrice)
                    {
                        leftmoney = Math.Abs(budjet - finalcurrentPrice);
                        Console.WriteLine($"Not enough money! You need {leftmoney:f2} leva.");
                    }
                }
            }
        }
    }
}
