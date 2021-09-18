using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console.ReadLine().Split().ToList();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                string comand = Console.ReadLine();
                string[] comandArray = comand.Split().ToArray();

                if (comandArray[0] == "Include")
                {
                    shops.Add(comandArray[1]);
                }
                else if (comandArray[0] == "Visit")
                {
                    int numberOfShop = int.Parse(comandArray[2]);
                    if (numberOfShop <= shops.Count && numberOfShop >= 0)
                    {

                        if (comandArray[1] == "first")
                        {
                            for (int j = 0; j < numberOfShop; j++)
                            {
                                shops.RemoveAt(0);
                            }
                        }
                        else if (comandArray[1] == "last")
                        {

                            for (int k = 1; k <= numberOfShop; k++)
                            {
                                shops.RemoveAt(shops.Count - 1);

                            }

                        }
                    }

                }
                else if (comandArray[0] == "Prefer")
                {
                    int shopIndex1 = int.Parse(comandArray[1]);
                    int shopIndex2 = int.Parse(comandArray[2]);
                    if (shopIndex1 >= 0 && shopIndex1 < shops.Count && shopIndex2 >= 0 && shopIndex2 < shops.Count)
                    {
                        string shop1 = shops[shopIndex1];
                        string shop2 = shops[shopIndex2];

                        shops.RemoveAt(shopIndex1);
                        shops.Insert(shopIndex1, shop2);
                        shops.RemoveAt(shopIndex2);
                        shops.Insert(shopIndex2, shop1);
                    }
                }
                else if (comandArray[0] == "Place")
                {
                    int shopIndex = int.Parse(comandArray[2]);

                    if (shopIndex >= 0 && shopIndex < shops.Count - 1)
                    {
                        shops.Insert(shopIndex + 1, comandArray[1]);
                    }

                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
