using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputTikets = Console.ReadLine();
            string[] tikets = inputTikets
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();


            string regex = @"[@#$^]";

            for (int i = 0; i < tikets.Length; i++)
            {
                string curenttiket = tikets[i];
                curenttiket = curenttiket.Trim();
               //for (int j = 0; j < curenttiket.Length; j++)
               //{
               //    char curentSymbol = (char)curenttiket[j];
               //    if(curentSymbol== ' ')
               //    {
               //       
               //       
               //    }
               //}
              
                
                if (curenttiket.Length == 20)
                {
                    MatchCollection tiket = Regex.Matches(curenttiket, regex);
                    string symbol = string.Empty;
                    int count = 0;
                    foreach (Match tikettt in tiket)
                    {
                        symbol = tikettt.Value;
                        count++;
                    }
                    if (count > 10 && count < 18)
                    {
                        Console.WriteLine($"ticket \"{curenttiket}\" - {count / 2}{symbol}");
                    }
                    else if (count > 18)
                    {
                        Console.WriteLine($"ticket \"{curenttiket}\" - {count / 2}{symbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{curenttiket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine("invalid ticket");
                }


            }
        }
    }
}
