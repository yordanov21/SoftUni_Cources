using System;

namespace _09._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = string.Empty;
            for (int i = 1; i <= 3; i++)
            {
                char letter = char.Parse(Console.ReadLine());
               
                word += letter.ToString();
            }
            Console.WriteLine(word);
        }
    }
}
