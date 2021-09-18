using System;
using System.Linq;
using System.Collections.Generic;


namespace _01Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
           SortedDictionary<string, List <string>> dictionary = new SortedDictionary<string, List<string>>();

            string inputWordsDefinition = Console.ReadLine();

            string[] wordsDefinitionList = inputWordsDefinition.Split(" | ");

            for (int i = 0; i < wordsDefinitionList.Length; i++)
            {
                string[] wordDefinition = wordsDefinitionList[i].Split(": ");
                string word = wordDefinition[0];
                string definition = wordDefinition[1];
                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new  List<string>();
                }
                dictionary[word].Add(definition);

            }

            string inputWordsKey = Console.ReadLine();

            string[] wordKeys = inputWordsKey.Split(" | ");

            for (int i = 0; i < wordKeys.Length; i++)
            {
                string wordKey = wordKeys[i];
                if (dictionary.ContainsKey(wordKey))
                {
                    Console.WriteLine(wordKey);
                   foreach(var definition in dictionary[wordKey].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                
                }
            }

            string lastCommand = Console.ReadLine();
            if (lastCommand == "List")
            {
               foreach(var kvp in dictionary)
                {
                    Console.Write(kvp.Key+" ");
                }
            }
            else if (lastCommand == "End")
            {
                return;
            }
        }
    }
}
