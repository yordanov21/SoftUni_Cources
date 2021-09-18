using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> colection = Console.ReadLine()
                  .Split()
                  .ToList();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "Stop")
                {
                    break;
                }
                string[] comandArr = comand
                    .Split()
                    .ToArray();

                if (comandArr[0] == "Delete")
                {
                    int index = int.Parse(comandArr[1]);
                    if (index >= -1 && index < colection.Count - 1)
                    {
                        int indexToRemove = index + 1;
                        colection.RemoveAt(indexToRemove);
                    }
                }
                else if (comandArr[0] == "Swap")
                {
                    if (colection.Contains(comandArr[1]) && colection.Contains(comandArr[2]))
                    {
                        string word1 = comandArr[1];
                        string word2 = comandArr[2];
                        for (int i = 0; i < colection.Count; i++)
                        {
                            if (comandArr[1] == colection[i])
                            {
                                colection[i] = word2;
                            }
                            else if (comandArr[2] == colection[i])
                            {
                                colection[i] = word1;
                            }
                        }
                    }
                }
                else if (comandArr[0] == "Put")
                {
                    int index = int.Parse(comandArr[2]);
                    if (index > 0 && index <= colection.Count + 1)
                    {
                        colection.Insert(index - 1, comandArr[1]);
                    }
                   else if (index == colection.Count - 1)
                   {
                       colection.Add(comandArr[1]);
                   }
                }
                else if (comandArr[0] == "Sort")
                {
                    colection.Sort();
                    colection.Reverse();
                }
                else if (comandArr[0] == "Replace")
                {
                    for (int i = 0; i < colection.Count - 1; i++)
                    {
                        string word1 = comandArr[1];
                        string word2 = comandArr[2];
                        
                      
                         if(comandArr[2] == colection[i])
                        {
                            colection[i] = word1;
                            break;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(string.Join(" ", colection));
        }
    }
}
