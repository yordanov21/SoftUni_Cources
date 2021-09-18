using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filterWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            for (int i = 0; i < filterWords.Length; i++)
            {             
                text = text.Replace(filterWords[i], new string('*', filterWords[i].Length));
            }
           
            Console.WriteLine(text);
        }
    }
}
