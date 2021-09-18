using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var legendariItem = new Dictionary<string, int>();
            legendariItem["shards"] = 0;
            legendariItem["fragments"] = 0;
            legendariItem["motes"] = 0;

            var itemDict = new SortedDictionary<string, int>();

            string obtained = string.Empty;
            bool lineBoll = true;
            while (lineBoll)
            {
                string[] line = Console.ReadLine().Split();
                for (int i = 0; i < line.Length - 1; i += 2)
                {
                    int quantity = int.Parse(line[i]);
                    string material = line[i + 1];
                    material = material.ToLower();

                    if(material== "shards"|| material == "fragments" || material == "motes")
                    {

                        legendariItem[material] += quantity;
                        if (legendariItem["shards"] >= 250)
                        {
                            legendariItem["shards"] -= 250;
                            obtained = "Shadowmourne obtained!";
                            lineBoll = false;
                            break;
                        }
                        if (legendariItem["fragments"] >= 250)
                        {
                            legendariItem["fragments"] -= 250;
                            obtained = "Valanyr obtained!";
                            lineBoll = false;
                            break;
                        }
                        if (legendariItem["motes"] >= 250)
                        {
                            legendariItem["motes"] -= 250;
                            obtained = "Dragonwrath obtained!";
                            lineBoll = false;
                            break;
                        }
                        
                    }
                    else
                    {
                        if (!itemDict.ContainsKey(material))
                        {
                            itemDict.Add(material, quantity);
                        }
                        else
                        {
                            itemDict[material] += quantity;
                        }
                    }
                }
            }

            Console.WriteLine(obtained);
            legendariItem = legendariItem.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(a=>a.Key, b=>b.Value);
            foreach(var item in legendariItem)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach(var item in itemDict)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
