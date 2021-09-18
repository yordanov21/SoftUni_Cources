using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _02Decipherin
{
    class Program
    {
        static void Main(string[] args)
        {       
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();
            string regex = @"^[d-z{},|#]+$";

            StringBuilder sb = new StringBuilder();

            Match match = Regex.Match(firstLine, regex);

            if (match.Success)
            {
                for (int i = 0; i < firstLine.Length; i++)
                {
                    char letter = (char)(firstLine[i] - 3);
                    sb.Append(letter);
                }
                string[] secondLineWords = secondLine.Split();
                string firstWord = secondLineWords[0];
                string seconfWord = secondLineWords[1];

                sb.Replace(firstWord, seconfWord);
                string decipher = sb.ToString();
                Console.WriteLine(decipher);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
           
        }
    }
}
