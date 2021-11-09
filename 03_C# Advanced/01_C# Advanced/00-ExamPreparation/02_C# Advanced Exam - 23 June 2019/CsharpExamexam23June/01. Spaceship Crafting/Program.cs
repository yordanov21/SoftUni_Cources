using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] chemicalLiquids = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] physicalItems= Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> chemicalLiquidsQueue = new Queue<int>();
            for (int i = 0; i < chemicalLiquids.Length; i++)
            {
                chemicalLiquidsQueue.Enqueue(chemicalLiquids[i]);
            }

            Stack<int> physicalItemsStack = new Stack<int>();
            for (int i = 0; i < physicalItems.Length; i++)
            {
                physicalItemsStack.Push(physicalItems[i]);
            }
            Dictionary<string, int> material = new Dictionary<string, int>();
            material["Glass"] = 0;
            material["Aluminium"] = 0;
            material["Lithium"] = 0;
            material["Carbon fiber"] = 0;
            
            while (true)
            {
                if(chemicalLiquidsQueue.Count ==0 || physicalItemsStack.Count ==0)
                {
                    break;
                }
                int chemicalItem = chemicalLiquidsQueue.Peek();
                int physicalItem = physicalItemsStack.Peek();
                int sumOfUtems = chemicalItem + physicalItem;
                if (sumOfUtems == 25)
                {
                    material["Glass"]++;
                    chemicalLiquidsQueue.Dequeue();
                    physicalItemsStack.Pop();
                }
                else if (sumOfUtems == 50)
                {
                    material["Aluminium"] ++;
                    chemicalLiquidsQueue.Dequeue();
                    physicalItemsStack.Pop();
                }
                else if (sumOfUtems == 75)
                {
                    material["Lithium"] ++;
                    chemicalLiquidsQueue.Dequeue();
                    physicalItemsStack.Pop();
                }
                else if (sumOfUtems == 100)
                {
                    material["Carbon fiber"] ++;
                    chemicalLiquidsQueue.Dequeue();
                    physicalItemsStack.Pop();
                }
                else
                {
                    chemicalLiquidsQueue.Dequeue();
                    int item = physicalItemsStack.Pop();
                    physicalItemsStack.Push(item + 3);
                }

            }

            var materialList = material.Where(x => x.Value > 0).ToDictionary(x => x.Key, y => y.Value);
            if (materialList.Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (chemicalLiquidsQueue.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",chemicalLiquidsQueue)}");
            }

            if (physicalItemsStack.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItemsStack)}");
            }

            foreach (var curentMaterial in material.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{curentMaterial.Key}: {curentMaterial.Value}");
            }

        }
    }
}
