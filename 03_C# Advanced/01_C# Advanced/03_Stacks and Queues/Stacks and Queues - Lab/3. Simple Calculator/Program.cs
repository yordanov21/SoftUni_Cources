using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var values = input.Split();   
            var symbols = new Stack<string>(values.Reverse());

            var result = int.Parse(symbols.Pop());

            while (symbols.Any())
            {
                var nextSym = symbols.Pop();
                if (nextSym == "+")
                {
                    var digit=int.Parse(symbols.Pop());
                    result += digit;
                }
                else if (nextSym == "-")
                {
                    var digit = int.Parse(symbols.Pop());
                    result -= digit;
                }
            }
            Console.WriteLine(result);
        }
    }
}
