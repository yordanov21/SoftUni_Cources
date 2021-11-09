using System;
using System.Collections.Generic;
using System.Linq;

namespace _07FoodShortage
{
    public class Program
    {
        static void Main()
        {
            List<IIndentifiable> all = new List<IIndentifiable>();
            List<IBirtday> allBirtdays = new List<IBirtday>();
           Dictionary<string,IBuyer> allBuyer = new Dictionary<string, IBuyer>();

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                var command = Console.ReadLine();
                var tokens = command.Split();
                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string bDate = tokens[3];
                    if (!allBuyer.ContainsKey(name))
                    {
                        allBuyer.Add(name,new Citizen(name, age, id, bDate));
                    }
                    
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];
                    if (!allBuyer.ContainsKey(name))
                    {
                        allBuyer.Add(name, new Rebel(name, age, group));
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (allBuyer.ContainsKey(command))
                {
                    allBuyer[command].BuyFood();
                }
            }

            int allFood = 0;
            foreach (var item in allBuyer)
            {
              var currentFood=  item.Value.Food;
                allFood += currentFood;
            }

            Console.WriteLine(allFood);
        }
    }
}
