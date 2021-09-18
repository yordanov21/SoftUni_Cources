using System;

namespace _06.TriplesLatinLett
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    for (int k = 0; k < num; k++)
                    {
                        char firstChar = (char)('a' + i);
                        char secondChar = (char)('a' + j);
                        char thirtChar = (char)('a' + k);

                        Console.Write($"{firstChar}{secondChar}{thirtChar}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
