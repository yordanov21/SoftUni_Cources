using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal change = decimal.Parse(Console.ReadLine());

            int counter = 0;
            if (change >= 2)
            {

                counter = (int)(change / (decimal)2);
                change %= 2;
            }
            if (change >= 1)
            {
                change %= 1;
                counter++;
            }
            if (change >= 0.5M)
            {
                change %= 0.50M;
                counter++;
            }
            if (change >= 0.2M)
            {
                counter += (int)(change / (decimal)0.2);
                change %= 0.20M;
            }
            if (change >= 0.1M)
            {
                change %= 0.10M;
                counter++;
            }
            if (change >= 0.05M)
            {
                change %= 0.05M;
                counter++;
            }
            if (change >= 0.02M)
            {
                counter += (int)(change / (decimal)0.02);
                change %= 0.02M;
            }
            if (change >= 0.01M)
            {
                change %= 0.01M;
                counter++;
            }



            Console.WriteLine(counter);




        }
    }
}

