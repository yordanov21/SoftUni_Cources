using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Coins3
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double changeCoins = change * 100;
            int counter = 0;
            while (changeCoins - 200 >= 0)
            {
                changeCoins -= 200;
                counter++;
                while (changeCoins >= 200)
                {
                    changeCoins -= 200;
                    counter++;
                }

                break;
                
            }
            while (changeCoins - 100 >= 0)
            {
                changeCoins -= 100;
                counter++;
                break;
            }
            while (changeCoins - 50 >= 0)
            {
                changeCoins -= 50;
                counter++;
                break;
            }
            while (changeCoins - 20 >= 0)
            {
                changeCoins -= 20;
                counter++;
                break;
            }
            while (changeCoins - 10 >= 0)
            {
                changeCoins -= 10;
                counter++;
                break;
            }
            while (changeCoins - 5 >= 0)
            {
                changeCoins -= 5;
                counter++;
                break;
            }
            while (changeCoins - 2 >= 0)
            {
                changeCoins -= 2;
                counter++;
                break;
            }
            while (changeCoins - 1 >= 0)
            {
                changeCoins -= 1;
                counter++;
                break;
            }
            Console.WriteLine( counter);
        }
    }
}
