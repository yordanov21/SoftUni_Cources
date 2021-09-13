using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int sumWord = 0;

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];
                switch (letter)
                {
                    case 'a': sumWord += 1; break;
                    case 'e': sumWord += 2; break;
                    case 'i': sumWord += 3; break;
                    case 'o': sumWord += 4; break;
                    case 'u': sumWord += 5; break;
                    default: break;
                }
            }
            Console.WriteLine(sumWord);
        }
    }
}
