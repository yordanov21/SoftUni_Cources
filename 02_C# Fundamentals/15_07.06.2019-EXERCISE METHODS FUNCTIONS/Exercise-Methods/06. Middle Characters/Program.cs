using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();

            if (comand.Length % 2 == 0)
            {
                MiddleCharEvenString(comand);
            }
            else
            {
                MiddleCharOddString(comand);
            }
        }
        static void MiddleCharEvenString(string comand)
        {
            Console.Write(comand[comand.Length / 2 - 1]);
            Console.Write(comand[comand.Length / 2]);
        }
        static void MiddleCharOddString(string comand)
        {
            Console.WriteLine(comand[comand.Length / 2]);
        }
    }
}
