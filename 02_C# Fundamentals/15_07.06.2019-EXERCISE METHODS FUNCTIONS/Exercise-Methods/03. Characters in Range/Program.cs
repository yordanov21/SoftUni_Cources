using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            if (firstChar <= secondChar)
            {
                PrintResult1(firstChar, secondChar);
            }
            else
            {
                PrintResult2(firstChar, secondChar);
            }
            
        }
        static void PrintResult1(char firstChar, char secondChar)
        {
            for (int i = firstChar + 1; i < secondChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
        static void PrintResult2(char firstChar, char secondChar)
        {
            for (int i = secondChar + 1; i < firstChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
