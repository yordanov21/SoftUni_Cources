using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n > 0 && n < 106)
            {
                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < n; i++)
                {
                    var line = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();
                    int command = line[0];
                    if (command == 1 && line[1] >= 1 && line[1] <= 105)
                    {

                        stack.Push(line[1]);
                    }
                    else if (command == 2 && stack.Any())
                    {

                        stack.Pop();

                    }
                    else if (command == 3)
                    {
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                       //else
                       //{
                       //    Console.WriteLine("0");
                       //}

                    }
                    else if (command == 4)
                    {
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                       // else
                       // {
                       //     Console.WriteLine("0");
                       // }

                    }
                }

                var list = stack.ToArray();
                if (list.Length > 0)
                {
                    Console.WriteLine(string.Join(", ", stack));
                }

            }
        }
    }
}
