using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientsInBasket = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            Queue<int> ingredientQueue = new Queue<int>();
            for (int i = 0; i < ingredientsInBasket.Length; i++)
            {
                ingredientQueue.Enqueue(ingredientsInBasket[i]);
            }

            var freshenessLevel = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            Stack<int> freshnessStack = new Stack<int>();
            for (int i = 0; i < freshenessLevel.Length; i++)
            {
                freshnessStack.Push(freshenessLevel[i]);
            }

            Dictionary<string, int> coctails = new Dictionary<string, int>();

            int countOperation = Math.Min(freshenessLevel.Length, ingredientsInBasket.Length);
            while (true)
            {
                if (freshnessStack.Count == 0 || ingredientQueue.Count == 0 )
                {
                    break;
                }

                if (ingredientQueue.Peek() == 0)
                {
                    ingredientQueue.Dequeue();
                    continue; //без него гърми кода в judge; 66t.
                }
                int ingredientValie = ingredientQueue.Peek();
                int freshenessValue = freshnessStack.Peek();
                int multiplication = ingredientValie * freshenessValue;
                if (multiplication == 150)
                {
                    if (!coctails.ContainsKey("Mimosa"))
                    {
                        coctails["Mimosa"] = 0;
                    }
                    coctails["Mimosa"]++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();                          
                }
                else if (multiplication == 250)
                {
                    if (!coctails.ContainsKey("Daiquiri"))
                    {
                        coctails["Daiquiri"] = 0;
                    }
                    coctails["Daiquiri"]++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop(); 
                }
                else if (multiplication == 300)
                {
                    if (!coctails.ContainsKey("Sunshine"))
                    {
                        coctails["Sunshine"] = 0;
                    }
                    coctails["Sunshine"]++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else if (multiplication == 400)
                {
                    if (!coctails.ContainsKey("Mojito"))
                    {
                        coctails["Mojito"] = 0;
                    }
                    coctails["Mojito"]++;
                    ingredientQueue.Dequeue();
                    freshnessStack.Pop();
                }
                else
                {                
                    freshnessStack.Pop();
                    int value=ingredientQueue.Dequeue();
                    ingredientQueue.Enqueue(5+value);
                }
            }

            if (coctails.Count == 4)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
                if (ingredientQueue.Any())
                {
                    Console.WriteLine($"Ingredients left: {ingredientQueue.Sum()}");
                }
            }

            coctails = coctails
                .OrderBy(x => x.Key)
                .Where(x => x.Value > 0)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var cocktail in coctails)
            {
                Console.WriteLine($"# {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}
