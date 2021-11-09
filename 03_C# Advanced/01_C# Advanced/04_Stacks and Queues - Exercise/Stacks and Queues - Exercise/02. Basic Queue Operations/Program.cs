using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] element = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            int queueElementsCount = element[0];
            int queueElementToRemove = element[1];
            int queueElementoToLook = element[2];

            Queue<int> queue= new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            for (int i = 0; i < queueElementToRemove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(queueElementoToLook) && queue.Count > 0)
            {

                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }

            }
        }
    }
}
