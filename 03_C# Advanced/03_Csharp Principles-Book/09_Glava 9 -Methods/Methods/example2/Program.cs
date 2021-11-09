using System;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberParam = 3;

            PrintNumber(numberParam);

            Console.WriteLine($"In Main() method numberParam is: {numberParam}");
        }

        static void PrintNumber(int numberParam)
        {
            numberParam = 5;

            Console.WriteLine($"In Printnumber() method, after the modification, numberParam is {numberParam}");
        }
    }
}
