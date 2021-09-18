using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {

            
            string word = Console.ReadLine();

            var dictionaryOfChars = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if(word[i]!=' ')
                {
                    if (!dictionaryOfChars.ContainsKey(word[i]))
                    {
                        dictionaryOfChars.Add(word[i], 1);
                    }
                    else
                    {
                        dictionaryOfChars[word[i]]++;
                    }
                }
            }
            foreach(var item in dictionaryOfChars)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
