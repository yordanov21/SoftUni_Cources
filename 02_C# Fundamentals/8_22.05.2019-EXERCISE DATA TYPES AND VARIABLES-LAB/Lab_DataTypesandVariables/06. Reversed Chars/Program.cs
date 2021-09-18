using System;

namespace _06._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = '0';
            char two = '0';
            char three = '0';

            for (int i = 1; i <= 3; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                if (i == 1)
                {
                    one = symbol;
                }
                else if (i == 2)
                {
                     two = symbol;
                }
                else
                {
                     three = symbol;
                }
             
            }
            Console.WriteLine($"{three} {two} {one}");
        }
    }
}
