using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Queue<string> queueMarket = new Queue<string>();
            while ((command = Console.ReadLine()) != "End")
            {
                if (command != "Paid")
                {
                    queueMarket.Enqueue(command);
                    
                }
                else
                {
                    while(queueMarket.Count!=0)
                    {
                        var curenntPerson = queueMarket.Dequeue();
                        Console.WriteLine(curenntPerson);
                    }
                }
            }

            Console.WriteLine($"{queueMarket.Count} people remaining.");

        }
    }
}
