using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            using (var wordReader = new StreamReader("words.txt"))
            {
                string line;
                while ((line = wordReader.ReadLine()) != null)
                {
                    string[] splitedLine = line.Split(" ",
                        StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();

                    words.AddRange(splitedLine);
                }
            }

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount[word] = 0;
                }
            }

            using (var reader = new StreamReader("text.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    StringBuilder newLine = new StringBuilder();
                    foreach (var symbol in line)
                    {
                        if (!char.IsPunctuation(symbol) || symbol == '\'')
                        {
                            newLine.Append(symbol);
                        }
                    }
                    string[] splitedLine = newLine.ToString()
                        .ToLower()   // in a different way to use ToLower()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splitedLine)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                    }

                }
            }

            var sortedDictionary = wordCount
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, y => y.Value);
            using (var readerResult = new StreamReader("expectedResult.txt"))
            {
                bool isSame = true;

                foreach (var kvp in sortedDictionary)
                {
                    string output = $"{kvp.Key} - {kvp.Value}";
                    string line = readerResult.ReadLine();

                    if (output != line)
                    {
                        isSame = false;
                        break;
                    }
                  
                }

                if (isSame)
                {
                    Console.WriteLine(true);
                }
            }

            using (var writer = new StreamWriter("actualResult.txt"))
            {
                foreach (var kvp in sortedDictionary)
                {
                    string output = $"{kvp.Key} - {kvp.Value}";
                    writer.WriteLine(output);
                }
            }
        }
    }
}
