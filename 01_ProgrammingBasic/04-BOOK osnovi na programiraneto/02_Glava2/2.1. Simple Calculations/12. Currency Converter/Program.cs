using System;

namespace _12._Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var coursLeva = 1.0;
            var coursUSD = 1.79549;
            var coursEuro = 1.95583;
            var coursGBP = 2.53405;

            var money = double.Parse(Console.ReadLine());
            var convertedMoney = 0.0;

            string enterCurrency = Console.ReadLine();
            string exitCurrency = Console.ReadLine();

            if (enterCurrency == "BGN")
            {
                if (exitCurrency == "USD")
                {
                    convertedMoney = money/coursUSD;
                    Console.WriteLine($"{convertedMoney:f2} USD");
              
                }
                else if (exitCurrency == "EUR")
                {
                    convertedMoney = money/coursEuro;
                    Console.WriteLine($"{convertedMoney:f2} EUR");
              
                }
                else if (exitCurrency == "GBP")
                {
                    convertedMoney =  money/coursGBP;
                    Console.WriteLine($"{convertedMoney:f2} GBP");
                  
                }

            }
            else if (enterCurrency == "USD")
            {
                if (exitCurrency == "BGN")
                {
                    convertedMoney =  money*coursUSD;
                    Console.WriteLine($"{convertedMoney:f2} BGN");
                }
                else if (exitCurrency == "EUR")
                {
                    convertedMoney = (coursUSD/coursEuro) * money;
                    Console.WriteLine($"{convertedMoney:f2} EUR");
                }
                else if (exitCurrency == "GBP")
                {
                    convertedMoney = coursUSD/coursGBP * money;
                    Console.WriteLine($"{convertedMoney:f2} GBP");
                }
            }
            else if (enterCurrency == "EUR")
            {
                if (exitCurrency == "BGN")
                {
                    convertedMoney = money*coursEuro;
                    Console.WriteLine($"{convertedMoney:f2} BGN");
                }
                else if (exitCurrency == "USD")
                {
                    convertedMoney = (coursEuro/coursUSD) * money;
                    Console.WriteLine($"{convertedMoney:f2} USD");
                }
                else if (exitCurrency == "GBP")
                {
                    convertedMoney =(coursEuro/ coursGBP) * money;
                    Console.WriteLine($"{convertedMoney:f2} GBP");
                }
            }
            else if (enterCurrency == "GBP")
            {
                if (exitCurrency == "BGN")
                {
                    convertedMoney = money * coursGBP;
                    Console.WriteLine($"{convertedMoney:f2} BGN");
                }
                else if (exitCurrency == "USD")
                {
                    convertedMoney = (coursGBP/coursUSD) * money;
                    Console.WriteLine($"{convertedMoney:f2} USD");
                }
                else if (exitCurrency == "EUR")
                {
                    convertedMoney = coursGBP / coursEuro * money;
                    Console.WriteLine($"{convertedMoney:f2} EUR");
                }
            }

        }
    }
}
