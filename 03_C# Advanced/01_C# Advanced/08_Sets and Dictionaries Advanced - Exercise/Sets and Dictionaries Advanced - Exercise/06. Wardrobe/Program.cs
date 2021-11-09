using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int countDres = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var token = input.Split(" -> ");
                var color = token[0];
                var cloats = token[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }
                for (int j = 0; j < cloats.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(cloats[j]))
                    {
                        wardrobe[color][cloats[j]] = 0;
                    }
                    wardrobe[color][cloats[j]]+=1;
                }
            }
        
            var searchedCloats = Console.ReadLine().Split();
            string searchedColor = searchedCloats[0];
            string searchedCloat = searchedCloats[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var dress in color.Value)
                {
                    string currentDress = dress.Key;
                    int countDress = dress.Value;
                    if(searchedColor==color.Key&&searchedCloat== currentDress)
                    {
                        Console.WriteLine($"* {currentDress} - {countDress} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currentDress} - {countDress}");
                    }
                  
                }
            }
        }
    }
}
