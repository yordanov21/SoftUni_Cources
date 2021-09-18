using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string manioulatur = string.Empty;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandArr = input.Split();
                string commnad = commandArr[0];

                if (commnad == "Add")
                {
                    manioulatur = manioulatur + commandArr[1];
                    
                }
                else if (commnad == "Upgrade")
                {
                    for (int i = 0; i < manioulatur.Length; i++)
                    {
                        char symbol =char.Parse(commandArr[1]);                       
                        manioulatur= manioulatur.Replace(symbol,(char)(symbol+1));                      
                    }
                  
                }
                else if (commnad == "Print")
                {
                    Console.WriteLine(manioulatur);
                }
                else if (commnad == "Index")
                {
                    List<int> index = new List<int>();
                    char symbol = char.Parse(commandArr[1]);
                    for (int i = 0; i < manioulatur.Length; i++)
                    {
                        if (manioulatur[i] == symbol)
                        {
                            index.Add(i);
                        }                        
                    }
                    if (index.Count > 0)
                    {
                        Console.WriteLine(string.Join(" ",index));
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }

                }
                else if (commnad == "Remove")
                {
                    string substring = commandArr[1];
                   manioulatur= manioulatur.Replace(substring, "");
                }
                

                input = Console.ReadLine();
            }
        }
    }
}
