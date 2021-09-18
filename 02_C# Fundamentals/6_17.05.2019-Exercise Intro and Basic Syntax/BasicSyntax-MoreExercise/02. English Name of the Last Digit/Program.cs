using System;

namespace _02._English_Name_of_the_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int lastN = num % 10;
            if (lastN == 0)
            {
                Console.WriteLine("zero");
            }
            else if (lastN == 1)
            {
                Console.WriteLine("one");
            }
            else if (lastN == 2)
            {
                Console.WriteLine("two");
            }
            else if (lastN == 3)
            {
                Console.WriteLine("three");
            }
            else if (lastN == 4)
            {
                Console.WriteLine("four");
            }
            else if (lastN == 5)
            {
                Console.WriteLine("five");
            }
            else if (lastN == 6)
            {
                Console.WriteLine("six");
            }
            else if (lastN == 7)
            {
                Console.WriteLine("seven");
            }
            else if (lastN == 8)
            {
                Console.WriteLine("eight");
            }
            else if (lastN == 9)
            {
                Console.WriteLine("nine");
            }
        }
    }
}
