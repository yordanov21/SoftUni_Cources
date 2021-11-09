using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main()
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            Bag bag = new Bag();

            string[] quantityOfTreager = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

     
            for (int i = 0; i < quantityOfTreager.Length; i += 2)
            {
                string typeOfTreager = quantityOfTreager[i];
                long quantity = long.Parse(quantityOfTreager[i + 1]);

                string currentTreager = string.Empty;

                if (typeOfTreager.Length == 3)
                {
                    if (!bag.CashStore.ContainsKey(typeOfTreager))
                    {
                        Cash cash = new Cash(typeOfTreager);
                        cash.AddCachQuantity(quantity);                       
                        bag.CashStore.Add(typeOfTreager, cash);
                    }
                    else
                    {
                        bag.AddCash(typeOfTreager, quantity);
                    }
                                                      
                }
                else if (typeOfTreager.ToLower().EndsWith("gem"))
                {
                    if (!bag.GemStore.ContainsKey(typeOfTreager))
                    {
                        Gem gem = new Gem(typeOfTreager);
                        gem.AddGemQuantity(quantity);
                        bag.GemStore.Add(typeOfTreager, gem);
                    }
                    else
                    {
                       bag.AddGem(typeOfTreager,quantity);
                    }
                }
                else if (typeOfTreager.ToLower() == "gold")
                {
                    bag.AddGold(quantity);
                }
              
                bag.Capacity += quantity;
               
                if (bagCapacity < bag.Capacity)
                {
                    break;
                }
                   
                
            }

            Console.WriteLine(bag.ToString());
        }
    }
}