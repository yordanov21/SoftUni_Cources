using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucher = int.Parse(Console.ReadLine());
            string purches = string.Empty;
            int tiketprice = 0;
            int PurchesPrice = 0;
            int valuePurches = vaucher;
            int counterTiket = 0;
            int counterPuches = 0;
            while (true)
            {
                purches = Console.ReadLine();
                if(purches == "End")
                {
                    break;
                }
                int dig = purches.Length;
                if (dig > 8)
                {
                    tiketprice = purches[0] + purches[1];
                    valuePurches -= tiketprice;
                    if (valuePurches < 0)
                    {
                        break;
                    }
                    counterTiket++;
                }
                else if (dig <= 8)
                {
                    PurchesPrice = purches[0];

                    if (PurchesPrice <valuePurches)
                    {
                        valuePurches -= PurchesPrice;
                        counterPuches++;
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
            Console.WriteLine(counterTiket);
            Console.WriteLine(counterPuches);
        }
    }
}
