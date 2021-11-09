using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] element = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int stackElementsCount = element[0];
            int stackElementToPop = element[1];
            int stackElementoToLook = element[2];

            Stack<int> stack = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            for (int i = 0; i < stackElementToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(stackElementoToLook)&&stack.Count>0)
            {

                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
               
            }
        }
    }
}
