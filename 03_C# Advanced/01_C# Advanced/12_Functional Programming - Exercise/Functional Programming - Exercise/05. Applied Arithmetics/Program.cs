using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Applied_Arithmetics
{
    public delegate int[] Calculation(int[] num);
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> printNumbers = nums => Console.WriteLine(string.Join(" ", nums));

            int[] numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            Calculation addOne = num => num.Select(x => x + 1).ToArray();
            Calculation multiply = num => num.Select(x => x * 2).ToArray();
            Calculation subtract = num => num.Select(x => x - 1).ToArray();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                   numbers= addOne(numbers);
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
        
        // public static int [] AddOne (int[] num)
        // {         
        //      return  num.Select(x => x + 1).ToArray();            
        // }
        // public static int[] Multiply (int[] num)
        // {
        //     return num.Select(x => x *2).ToArray();
        // }
        // public static int[] Subtract(int[] num)
        // {
        //     return num.Select(x => x -1).ToArray();
        // }

    }
}
