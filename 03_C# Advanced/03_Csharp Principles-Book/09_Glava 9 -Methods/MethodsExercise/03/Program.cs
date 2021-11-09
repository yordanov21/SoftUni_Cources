using System;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(ReturnLastNumberAsString(number));

        }

        static string ReturnLastNumberAsString(int number)
        {
            int lastNumber = number % 10;
            if (lastNumber == 0)
            {
                return "zero";
            }
            else if (lastNumber == 1)
            {
                return "one";
            }
            else if (lastNumber == 2)
            {
                return "two";
            }
            else if (lastNumber == 3)
            {
                return "trhee";
            }
            else if (lastNumber == 4)
            {
                return "four";
            }
            else if (lastNumber == 5)
            {
                return "five";
            }
            else if (lastNumber == 6)
            {
                return "six";
            }
            else if (lastNumber == 7)
            {
                return "seven";
            }
            else if (lastNumber == 8)
            {
                return "eight";
            }
            else
            {
                return "nine";
            }

        }
    }
}
