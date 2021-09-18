using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < count; i++)
            {
                var word = Console.ReadLine();
                var synonym = Console.ReadLine();
                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                    //dict.Add(word,new List<string>());
                }
                dict[word].Add(synonym);
            }

            foreach (var item in dict)
            {
                var word = item.Key;
                var synonyms = item.Value;

                Console.WriteLine($"{word} - {string.Join(", ", synonyms)}");
            }
        }
    }
}
