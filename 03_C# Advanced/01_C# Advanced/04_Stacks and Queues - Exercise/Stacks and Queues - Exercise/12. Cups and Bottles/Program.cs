using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> bottlesStack = new Stack<int>(bottles);
            Queue<int> cupsQueue = new Queue<int>(cups);
            int allWastedWater = 0;
            int wastedWater = 0;
            while (true)
            {
                if (bottlesStack.Count > 0 && cupsQueue.Count > 0)
                {
                    var currentBottle = bottlesStack.Pop();
                    var currentCub = cupsQueue.Peek();
                    if (currentCub <= currentBottle)
                    {
                        cupsQueue.Dequeue();
                        wastedWater = currentBottle - currentCub;
                        allWastedWater += wastedWater;
                    }
                    else
                    {
                        currentCub -= currentBottle;
                        while (currentCub > 0)
                        {
                            currentBottle = bottlesStack.Pop();
                            currentCub -= currentBottle;
                        }
                        wastedWater = -currentCub;
                        allWastedWater += wastedWater;
                        cupsQueue.Dequeue();
                    }
                }
                else
                {
                    break;
                }

            }
            if (bottlesStack.Count != 0)
            {

                Console.WriteLine($"Bottles: {string.Join(" ",bottlesStack)}");
            }
            else if (cupsQueue.Count!=0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsQueue)}");
            }

            Console.WriteLine($"Wasted litters of water: {allWastedWater}");
        }
    }
}
