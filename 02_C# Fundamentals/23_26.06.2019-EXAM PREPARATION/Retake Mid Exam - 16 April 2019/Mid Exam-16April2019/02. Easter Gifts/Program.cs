using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine()
                 .Split()
                 .ToList();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "No Money")
                {
                    break;
                }

                string[] comandArray = comand.Split().ToArray();
                if(comandArray[0]== "OutOfStock")
                {
                    for (int i = 0; i < gifts.Count; i++)
                    {
                        if (comandArray[1] == gifts[i])
                        {
                            gifts[i] = "None";
                        }
                    }
                }
                else if(comandArray[0] == "Required")
                {
                    int indexGift = int.Parse(comandArray[2]);
                    if (indexGift < gifts.Count-1 && indexGift >= 0)
                    {
                        gifts.RemoveAt(indexGift);
                        gifts.Insert(indexGift, comandArray[1]);
                    }
                   
                }
                else if (comandArray[0] == "JustInCase")
                {
                    gifts.RemoveAt(gifts.Count - 1);
                    gifts.Add(comandArray[1]);
                }

                
            }
            for (int i = 0; i < gifts.Count; i++)
            {
                gifts.Remove("None");
            }
            Console.WriteLine(string.Join(" ",gifts));
        }
    }
}
