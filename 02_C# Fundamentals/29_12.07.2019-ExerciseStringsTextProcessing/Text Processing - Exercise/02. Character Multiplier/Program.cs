using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string word1 = words[0];
            string word2 = words[1];

            int sum = 0;

            for (int i = 0; i < word1.Length; i++)
            {
                sum += word1[i] * word2[i];

                if ((i + 1).Equals(word2.Length))
                {
                    break;
                }
            }

            if (word1.Length > word2.Length)
            {
                for (int i = word2.Length; i < word1.Length; i++)
                {
                    sum += word1[i];
                }
            }
            else if (word2.Length > word1.Length)
            {
                for (int i = word1.Length; i < word2.Length; i++)
                {
                    sum += word2[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}