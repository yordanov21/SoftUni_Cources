using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var allChildren = Console.ReadLine().Split();
            Queue<string> children = new Queue<string>(allChildren);

            var number = int.Parse(Console.ReadLine());
            int counter = 1;

            while (children.Count > 1)
            {
                var currentCildren = children.Dequeue();
                if (counter % number != 0)
                {
                    children.Enqueue(currentCildren);
                }
                else
                {
                    Console.WriteLine($"Removed {currentCildren}");
                }
                counter++;
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
       
    }
}
