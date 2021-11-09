using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            var queueOrders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            int ordersSum = 0;

            Console.WriteLine(queueOrders.Max());
            while(queueOrders.Count>0)
            {
                int order = queueOrders.Peek();
                ordersSum += order;
                if (ordersSum <= foodQuantity)
                {
                    queueOrders.Dequeue();
                }
                else
                {
                    break;
                }
              
            }

            if (queueOrders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOrders)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        
        }
    }
}
