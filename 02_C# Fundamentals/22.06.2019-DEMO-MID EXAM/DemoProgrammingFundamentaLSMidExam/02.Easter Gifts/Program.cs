using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> giffts = Console.ReadLine()
                .Split()
                .ToList();
            while (true)
            {
                string anotherGift = Console.ReadLine();
                if(anotherGift== "No Money")
                {
                    break;
                }
                string [] anotherGiftArray=anotherGift
                    .Split()
                    .ToArray();
                if(anotherGiftArray[0]== "OutOfStock")
                {
                    for (int i = 0; i < giffts.Count; i++)
                    {
                        if (anotherGiftArray[1] == giffts[i])
                        {
                            giffts[i] = "None";
                        }
                    }
                }
                if(anotherGiftArray[0] == "Required")
                {
                    int requiredNumber = int.Parse(anotherGiftArray[2]);
                    if (requiredNumber >= giffts.Count)
                    {
                        continue;
                    }
                    giffts[requiredNumber] = anotherGiftArray[1];
                }
                if (anotherGiftArray[0] == "JustInCase")
                {
                   
                    giffts[giffts.Count-1] = anotherGiftArray[1];
                }
            }

            for (int i = 0; i < giffts.Count; i++)
            {
                if (giffts[i] == "None")
                {
                    giffts.RemoveAt(i);
                }
            }
            Console.WriteLine(string.Join(" ",giffts));
        
        }
    }
}
