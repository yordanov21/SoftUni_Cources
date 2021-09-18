using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int counter = 0;

            Console.WriteLine(Counter(counter, word));
        }
        static int Counter(int counter, string word )
        {
            char[] vowels = { 'o', 'i', 'a', 'u', 'e' };
            for (int i = 0; i < word.Length; i++)
            {
                int currentSymbol = word[i];
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (currentSymbol == vowels[j])
                    {
                        counter++;
                    }
                }


            }
            return counter;
        }
    }
}
