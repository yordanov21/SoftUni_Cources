using System;
using System.Linq;
using System.Collections.Generic;


namespace _02._OnWayAnnapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputArr = input
                    .Split("->");
                string command = inputArr[0];

                if (command == "Add")
                {
                    string storeName = inputArr[1];
                    string itemString = inputArr[2];
                    string[] item = itemString.Split(",");
                    if (item.Length == 1)
                    {

                        if (!stores.ContainsKey(storeName))
                        {
                            stores[storeName] = new List<string>();
                        }
                        stores[storeName].Add(item[0]);
                    }
                    else
                    {
                        if (!stores.ContainsKey(storeName))
                        {
                            stores[storeName] = new List<string>();
                        }
                        for (int i = 0; i < item.Length; i++)
                        {
                            stores[storeName].Add(item[i]);
                        }
                    }

                }
                else if (command == "Remove")
                {
                    string storeName = inputArr[1];
                    if (stores.ContainsKey(storeName))
                    {
                        stores.Remove(storeName);
                    }
                }

                input = Console.ReadLine();
            }

           stores= stores
                .OrderByDescending(x => x.Value.Count)
                .ThenByDescending(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            if (stores.Any())
            {
                Console.WriteLine("Stores list:");
                foreach(var store in stores)
                {
                    Console.WriteLine(store.Key);
                    foreach(var item in store.Value)
                    {
                        Console.WriteLine($"<<{item}>>");
                    }
                }
            }
        }
    }
}
