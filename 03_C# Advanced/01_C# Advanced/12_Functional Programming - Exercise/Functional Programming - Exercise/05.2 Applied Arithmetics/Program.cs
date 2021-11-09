using System;
using System.Linq;
using System.Collections.Generic;


namespace _05._2_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
           Func<int[],int[]> addOne = num => num.Select(x => x + 1).ToArray();
           Func<int[],int[]> multiply = num => num.Select(x => x * 2).ToArray();
           Func<int[],int[]> subtract = num => num.Select(x => x - 1).ToArray();
            Action<int[]> printNumbers = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
           
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    numbers = addOne(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "print")
                {
                    printNumbers(numbers);
                }
            }
        }
    }
}
