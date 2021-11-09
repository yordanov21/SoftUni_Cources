using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var commandLine = Console.ReadLine().ToLower();
            Stack<int> stack = new Stack<int>(input);

            while (commandLine != "end")
            {
                var comand = commandLine.Split().ToArray();
                var curendComand = comand[0].ToLower();
                if (curendComand == "add")
                {
                    stack.Push(int.Parse(comand[1]));
                    stack.Push(int.Parse(comand[2]));

                }
                else if (curendComand == "remove")
                {
                    var numForRemove = int.Parse(comand[1]);
                    if (numForRemove < stack.Count)
                    {
                        for (int i = 0; i < numForRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (curendComand == "end")
                {
                    break;
                }

                commandLine = Console.ReadLine().ToLower();
            }
            var sum = 0;

            while (stack.Any())
            {
                sum += stack.Pop();
            }
            Console.WriteLine("Sum: "+sum);
        }

    }
}
