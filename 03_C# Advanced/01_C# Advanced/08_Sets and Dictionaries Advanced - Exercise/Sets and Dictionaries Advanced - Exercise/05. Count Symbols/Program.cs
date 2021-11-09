using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> countSymbols = new SortedDictionary<char, int>();
            for (int i= 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (!countSymbols.ContainsKey(symbol))
                {
                    countSymbols[symbol] = 0;
                }
                countSymbols[symbol] += 1;
            }
            foreach (var symbol in countSymbols)
            {
                char curentSymbol = symbol.Key;
                int symbolCount = symbol.Value;
                Console.WriteLine($"{curentSymbol}: {symbolCount} time/s");
            }
        }
    }
}
